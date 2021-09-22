using AutoMapper;
using Domain.DTO.Despesas;
using Domain.Entities.Planejamento;
using Domain.Interfaces;
using Domain.Repository.Despesas;
using Domain.Utils;
using System;
using System.Threading.Tasks;

namespace Service.Despesa
{
    public class TipoDespesaService : ITipoDesepesaService
    {
        private readonly IMapper mapper;
        private ITipoDespesaRepository tipoDespesaRepository;

        public TipoDespesaService(ITipoDespesaRepository _tipoDespesaRepository,IMapper _mapper)
        {
            mapper = _mapper;
            tipoDespesaRepository = _tipoDespesaRepository;
        }

        public async Task<Response> DoRegisterAsync(TipoDespesaRegisterDTO register)
        {
            try
            {
                TipoDespesaEntity tipoDespesa = mapper.Map<TipoDespesaEntity>(register);
                var result = await tipoDespesaRepository.InsertAsync(tipoDespesa);

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
                return new Response(500, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }
    }
}
