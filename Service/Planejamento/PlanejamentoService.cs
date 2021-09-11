using AutoMapper;
using AutoMapper.Configuration;
using Domain.DTO.Planejamento;
using Domain.Entities.Planejamento;
using Domain.Interfaces;
using Domain.Repository.Planejamento;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Planejamento
{
    public class PlanejamentoService : IPlanejamentoService
    {
        private IPlanejamentoRepository planejamentoRepository;
        private readonly IMapper mapper;
        

        public PlanejamentoService(IPlanejamentoRepository _planejamento,IMapper _mapper)
        {
            mapper = _mapper;
            planejamentoRepository = _planejamento;

        }

        public async Task<Response> DoRegisterAsync(PlanejamentoRegisterDTO register)
        {
            try
            {
                PlanejamentoEntity planejamento = mapper.Map<PlanejamentoEntity>(register);

                planejamento.DataInicio = new DateTime(planejamento.AnoReferencia, (int)planejamento.MesReferencia, 1); ;
                planejamento.DataFim = new DateTime(planejamento.AnoReferencia, (int)planejamento.MesReferencia, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

                planejamento.Ativo = true;

                bool hasPlanejamento = planejamentoRepository.ExistAsync(p => p.MesReferencia.Equals(planejamento.MesReferencia) 
                && p.AnoReferencia.Equals(planejamento.AnoReferencia) 
                && p.IdUsuario == planejamento.IdUsuario);
                    
                if(hasPlanejamento)
                    return new Response(400, "Já existe um planejamento cadastrado nesse período.");

                var result = await planejamentoRepository.InsertAsync(planejamento);

                if (result != null)
                {
                    AtualizarPlanejamentoAtivo(result);
                    return new Response(201, "Planejamento cadastrado com sucesso!");
                }
                else
                    return new Response(400, "Erro ao cadastrar usuário!");

            }
            catch (Exception ex)
            {
                return new Response(500, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }

        public PlanejamentoDTO GetPlanejamentoAtivoByUser(Guid idUser)
        {
            try
            {
                var planejamento = planejamentoRepository.GetPlanejamentoAtivoByUser(idUser);
                PlanejamentoDTO planejamentoDTO = mapper.Map<PlanejamentoDTO>(planejamento);

                return planejamentoDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza o planejamento ativo, para deixar somente o que foi cadastrado.
        /// </summary>
        /// <param name="planejamento"></param>
        /// <returns></returns>
        public void AtualizarPlanejamentoAtivo(PlanejamentoEntity planejamento)
        {
            PlanejamentoEntity planejamentoAtivo = planejamentoRepository
                                                                .SelectWithFilter(p => p.Ativo == true 
                                                                    && p.Id != planejamento.Id
                                                                    && p.IdUsuario == planejamento.IdUsuario)
                                                                .FirstOrDefault();
            if(planejamentoAtivo != null)
            {
                planejamentoAtivo.Ativo = false;
                planejamentoRepository.UpdateAsync(planejamentoAtivo);
            }
    
        }
    }
}
