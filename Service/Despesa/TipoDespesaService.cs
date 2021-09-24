using AutoMapper;
using Domain.DTO.Despesas;
using Domain.Entities.Planejamento;
using Domain.Interfaces;
using Domain.Repository.Despesas;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Despesa
{
    public class TipoDespesaService : ITipoDesepesaService
    {
        private readonly IMapper mapper;
        private ITipoDespesaRepository tipoDespesaRepository;

        public TipoDespesaService(ITipoDespesaRepository _tipoDespesaRepository, IMapper _mapper)
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

        public async Task<Response> GetAll(Guid idUser)
        {
            try
            {
                List<TipoDespesaEntity> listTipoDespesa = tipoDespesaRepository.SelectWithFilter(t => t.IdUsuario.Equals(idUser)).ToList();

                if (listTipoDespesa.Count != 0)
                {
                    return new Response(200, listTipoDespesa);
                }
                else
                {
                    return new Response(204, "Não foram encontrados nenhum tipo despesa cadastrado para o usuário.");
                }
            }
            catch (Exception ex)
            {
                return new Response(500, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }

        public async Task<Response> GetByID(Guid id)
        {
            try
            {
                TipoDespesaEntity tipoDespesa = await tipoDespesaRepository.SelectAsync(id);

                if (tipoDespesa != null)
                {
                    return new Response(200, tipoDespesa);
                }
                else
                {
                    return new Response(204, "Não foram encontrados nenhum tipo despesa cadastrado para o usuário.");
                }
            }
            catch (Exception ex)
            {
                return new Response(500, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }
    }
}

