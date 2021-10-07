using AutoMapper;
using Domain.DTO.Despesas;
using Domain.Entities.Planejamento;
using Domain.Interfaces;
using Domain.Repository.Despesas;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Service.Despesa
{
    public class TipoDespesaService : ITipoDesepesaService
    {
        private readonly IMapper mapper;
        private ITipoDespesaRepository tipoDespesaRepository;
        private IDespesaRepository despesaRepository;

        public TipoDespesaService(ITipoDespesaRepository _tipoDespesaRepository, IMapper _mapper, IDespesaRepository _despesaRepository)
        {
            mapper = _mapper;
            tipoDespesaRepository = _tipoDespesaRepository;
            despesaRepository = _despesaRepository;
        }

        public async Task<Response> Delete(Guid id)
        {
            try
            {
                bool temDespesaCadastraComTipo =  despesaRepository.ExistAsync(d => d.IdTipoDespesa.Equals(id));

                if (temDespesaCadastraComTipo)
                {
                    return new Response((int)HttpStatusCode.Conflict, "O tipo de despesa/receita não pode ser excluído, pois ele está vinculado a uma despesa.");
                }
                else
                {
                    await tipoDespesaRepository.DeleteAsync(id);
                    return new Response((int)HttpStatusCode.OK, "Registro excluído com sucesso!");
                }
            }
            catch (Exception ex)
            {

               return new Response((int)HttpStatusCode.BadRequest, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
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
                return new Response((int)HttpStatusCode.BadRequest, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }

        public Task<Response> DoUpdateAsync(TipoDespesaRegisterDTO update)
        {
            throw new NotImplementedException();
        }

        public Response GetAll(Guid idUser)
        {
            try
            {
                List<TipoDespesaEntity> listTipoDespesa = tipoDespesaRepository.SelectWithFilter(t => t.IdUsuario.Equals(idUser)).ToList();

                if (listTipoDespesa.Count != 0)
                {
                    return new Response((int)HttpStatusCode.OK, listTipoDespesa);
                }
                else
                {
                    return new Response((int)HttpStatusCode.NoContent, "Não foram encontrados nenhum tipo despesa cadastrado para o usuário.");
                }
            }
            catch (Exception ex)
            {
                return new Response((int)HttpStatusCode.BadRequest, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }

        public async Task<Response> GetByID(Guid id)
        {
            try
            {
                TipoDespesaEntity tipoDespesa = await tipoDespesaRepository.SelectAsync(id);

                if (tipoDespesa != null)
                {
                    return new Response((int)HttpStatusCode.OK, tipoDespesa);
                }
                else
                {
                    return new Response((int)HttpStatusCode.NoContent, "Não foram encontrados nenhum tipo despesa cadastrado para o usuário.");
                }
            }
            catch (Exception ex)
            {
                return new Response((int)HttpStatusCode.BadRequest, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }
    }
}

