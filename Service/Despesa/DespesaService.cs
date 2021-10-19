using AutoMapper;
using Domain.DTO.Despesas;
using Domain.Entities.Expenses;
using Domain.Entities.Planejamento;
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

        public DespesaService(IMapper _mapper, IDespesaRepository _despesaRepository, IPlanejamentoRepository _planejamento)
        {
            mapper = _mapper;
            despesaRepository = _despesaRepository;
            planejamentoRepository = _planejamento;
        }

        public async Task<Response> DoRegisterAsync(DespesaRegisterDTO register)
        {
            try
            {
                DespesasEntity despesa = mapper.Map<DespesasEntity>(register);

                despesa.ValorTotal = despesa.ValorParcela * despesa.QuantidadeParcelas;

                var result = await despesaRepository.InsertAsync(despesa);

                CadastrarDespesasNoPlanejamento(despesa);

                if (result != null)
                {
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


        public void CadastrarDespesasNoPlanejamento(DespesasEntity despesa)
        {
            for (int i = 0; i < despesa.QuantidadeParcelas; i++)
            {
                int mesReferencia = DateTime.Now.Month + i;
                int anoReferencia = DateTime.Now.Year;

                PlanejamentoEntity planejamento = BuscarPlanejamento(despesa.IdUsuario, mesReferencia, anoReferencia);

                if(planejamento != null)
                {

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
