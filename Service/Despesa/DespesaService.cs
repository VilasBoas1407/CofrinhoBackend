using AutoMapper;
using Domain.DTO.Despesas;
using Domain.DTO.Planejamento;
using Domain.Entities.Expenses;
using Domain.Entities.Planejamento;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Repository.Despesas;
using Domain.Repository.Planejamento;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Despesa
{
    public class DespesaService : IDespesaService
    {
        private readonly IMapper mapper;
        private IDespesaRepository despesaRepository;
        private IPlanejamentoRepository planejamentoRepository;
        private IPlanejamentoService planejamentoService;
        private IPlanejamentoDespesaService planejamentoDespesaService;

        public DespesaService(IMapper _mapper, IDespesaRepository _despesaRepository,
            IPlanejamentoRepository _planejamentoRepository, IPlanejamentoService _planejamentoService, IPlanejamentoDespesaService _planejamentoDespesaService)
        {
            mapper = _mapper;
            despesaRepository = _despesaRepository;
            planejamentoRepository = _planejamentoRepository;
            planejamentoService = _planejamentoService;
            planejamentoDespesaService = _planejamentoDespesaService;
        }

        public async Task<Response> DoRegisterAsync(DespesaDTO register)
        {
            try
            {
                DespesasEntity despesa = mapper.Map<DespesasEntity>(register);

                ValidarDespesa(despesa);              
             
                var result = await despesaRepository.InsertAsync(despesa);

                if (result != null)
                {
                    CadastrarDespesasNoPlanejamento(despesa);

                    return new Response(201, "Tipo despesa cadastrado com sucesso!");
                }
                else
                {
                    return new Response(400, "Erro ao cadastrar tipo despesa!");
                }


            }
            catch (Exception ex)
            {
                return new Response((int)HttpStatusCode.BadRequest, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }

        public void ValidarDespesa(DespesasEntity despesa)
        {
            //Caso seja enviado uma despesa com 12X ela não será recorrente.
            if (despesa.QuantidadeParcelas >= 1)
                despesa.Recorrencia = false;

            //Caso a quantidade de parcelas seja 0 irá interferir no valor total
            if (despesa.QuantidadeParcelas == 0)
                despesa.QuantidadeParcelas = 1;


            despesa.ValorTotal = despesa.ValorParcela * despesa.QuantidadeParcelas;
        }

        public async void CadastrarDespesasNoPlanejamento(DespesasEntity despesa)
        {
            for (int i = 0; i < despesa.QuantidadeParcelas; i++)
            {
                int mesReferencia = DateTime.Now.Month + i;
                int anoReferencia = DateTime.Now.Year;

                PlanejamentoEntity planejamentoAtivo = BuscarPlanejamento(despesa.IdUsuario, mesReferencia, anoReferencia);

                //Caso o planejamento seja nulo, devemos cadastrar ele.
                if (planejamentoAtivo == null)
                {
                    PlanejamentoRegisterDTO planejamento = new PlanejamentoRegisterDTO
                    {
                        AnoReferencia = anoReferencia,
                        MesReferencia = mesReferencia,
                        IdUsuario = despesa.IdUsuario
                    };

                    Response response = await planejamentoService.DoRegisterAsync(planejamento);

                    PlanejamentoEntity planejamentoCadastrado = response.Result;

                    PlanejamentoDespesaDTO planejamentoDespesa = new PlanejamentoDespesaDTO
                    {
                        IdUsuario = planejamentoCadastrado.IdUsuario,
                        IdPlanejamento = planejamentoCadastrado.Id,
                        IdDespesa = despesa.Id
                    };

                    //Cadastrar vinculo da despesa com o planejamento
                    await planejamentoDespesaService.DoRegisterAsync(planejamentoDespesa);
                }
                else
                {
                    PlanejamentoDespesaDTO planejamentoDespesa = new PlanejamentoDespesaDTO
                    {
                        IdUsuario = planejamentoAtivo.IdUsuario,
                        IdPlanejamento = planejamentoAtivo.Id,
                        IdDespesa = despesa.Id
                    };

                    //Cadastrar vinculo da despesa com o planejamento
                    await planejamentoDespesaService.DoRegisterAsync(planejamentoDespesa);
                }
            }
        }

        public PlanejamentoEntity BuscarPlanejamento(Guid IdUsuario, int mesReferencia, int AnoReferencia)
        {
            return planejamentoRepository.
                SelectWithFilter(p => p.IdUsuario.Equals(IdUsuario) &&
                p.MesReferencia.Equals(mesReferencia) &&
                p.AnoReferencia.Equals(AnoReferencia)).FirstOrDefault();
        }
    }
}
