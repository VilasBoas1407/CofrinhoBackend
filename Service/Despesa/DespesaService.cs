using AutoMapper;
using Domain.DTO.Despesas;
using Domain.DTO.Planejamento;
using Domain.Entities.Expenses;
using Domain.Entities.Planejamento;
using Domain.Interfaces;
using Domain.Repository.Despesas;
using Domain.Repository.Planejamento;
using Domain.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Despesa
{
    public class DespesaService : IDespesaService
    {
        private readonly IMapper mapper;
        private IDespesaRepository despesaRepository;
        private IPlanejamentoService planejamentoService;
        private IPlanejamentoDespesaService planejamentoDespesaService;
        private ITipoDespesaRepository tipoDespesaRepository;

        public DespesaService(IMapper _mapper, IDespesaRepository _despesaRepository,
            ITipoDespesaRepository _tipoDespesaRepository,
            IPlanejamentoService _planejamentoService,
            IPlanejamentoDespesaService _planejamentoDespesaService)
        {
            mapper = _mapper;
            despesaRepository = _despesaRepository;
            planejamentoService = _planejamentoService;
            planejamentoDespesaService = _planejamentoDespesaService;
            tipoDespesaRepository = _tipoDespesaRepository;
        }

        public Response DoRegister(DespesaDTO register)
        {
            try
            {
                DespesasEntity despesa = mapper.Map<DespesasEntity>(register);

                ValidarDespesa(despesa);              
             
                var result = despesaRepository.Insert(despesa);

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
            catch (InternalException ex)
            {
                return new Response(ex.HttpStatusCode, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }

        public bool ValidarDespesa(DespesasEntity despesa)
        {
            //Caso seja enviado uma despesa com 12X ela não será recorrente.
            if (despesa.QuantidadeParcelas >= 1)
                despesa.Recorrencia = false;

            //Caso a quantidade de parcelas seja 0 irá interferir no valor total
            if (despesa.QuantidadeParcelas == 0)
                despesa.QuantidadeParcelas = 1;


            despesa.ValorTotal = despesa.ValorParcela * despesa.QuantidadeParcelas;

            bool temTipoDespesaCadastrado = tipoDespesaRepository.Exist(despesa.IdTipoDespesa);

            if (!temTipoDespesaCadastrado)
            {
                throw new InternalException(200,"O tipo despesa não foi encontrado na nossa base de dados!");
            }

            return true;
        }

        public void CadastrarDespesasNoPlanejamento(DespesasEntity despesa)
        {
            PlanejamentoEntity ultimoPlanejamentoCadastrado = new PlanejamentoEntity();

            int mesReferencia = DateTime.Now.Month;
            int anoReferencia = DateTime.Now.Year;

            for (int i = 0; i < despesa.QuantidadeParcelas; i++)
            {
                if(i != 0)
                    mesReferencia += 1;

                PlanejamentoEntity planejamentoAtivo = planejamentoService.BuscarPlanejamentoComMesEAno(despesa.IdUsuario, mesReferencia, anoReferencia);

                //Caso o planejamento seja nulo, devemos cadastrar ele.
                if (planejamentoAtivo == null)
                {
     
                    PlanejamentoRegisterDTO planejamento = new PlanejamentoRegisterDTO
                    {
                        AnoReferencia = anoReferencia,
                        MesReferencia = mesReferencia,
                        IdUsuario = despesa.IdUsuario,
                        Ativo = false
                    };

                    Response response = planejamentoService.DoRegister(planejamento);

                    PlanejamentoEntity planejamentoCadastrado = response.Result;

                    PlanejamentoDespesaDTO planejamentoDespesa = new PlanejamentoDespesaDTO
                    {
                        IdUsuario = planejamentoCadastrado.IdUsuario,
                        IdPlanejamento = planejamentoCadastrado.Id,
                        IdDespesa = despesa.Id
                    };

                    //Cadastrar vinculo da despesa com o planejamento
                    planejamentoDespesaService.DoRegister(planejamentoDespesa);
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
                    planejamentoDespesaService.DoRegister(planejamentoDespesa);
                }
            }
        }
    }
}
