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

        public Response DoRegister(PlanejamentoRegisterDTO register)
        {
            try
            {
                PlanejamentoEntity planejamento = mapper.Map<PlanejamentoEntity>(register);

                planejamento.DataInicio = new DateTime(planejamento.AnoReferencia, (int)planejamento.MesReferencia, 1); 
                planejamento.DataFim = new DateTime(planejamento.AnoReferencia, (int)planejamento.MesReferencia, DateTime.DaysInMonth((int)planejamento.AnoReferencia,(int) planejamento.MesReferencia));

                bool hasPlanejamento = ExistePlanejamentoComMesEAno(planejamento.IdUsuario, (int)planejamento.MesReferencia, (int)planejamento.AnoReferencia);

                if (hasPlanejamento)
                    return new Response(400, "Já existe um planejamento cadastrado nesse período.");

                var result = planejamentoRepository.Insert(planejamento);

                if (result != null)
                {
                    if(register.AtualizarPlanejamentoAtivo)
                        AtualizarPlanejamentoAtivo(result);
                    return new Response(201, "Planejamento cadastrado com sucesso!",result);
                }
                else
                    return new Response(400, "Erro ao cadastrar planejamento!");

            }
            catch (Exception ex)
            {
                return new Response(500, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }

        public PlanejamentoDTO GetPlanejamentoAtivoByUser(Guid IdUsuario)
        {
            try
            {
                var planejamento = planejamentoRepository.GetPlanejamentoAtivoByUser(IdUsuario);
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
                planejamentoRepository.Update(planejamentoAtivo);
            }

        }

        public PlanejamentoEntity BuscarPlanejamentoComMesEAno(Guid IdUsuario, int MesReferencia, int AnoReferencia)
        {
           return planejamentoRepository.SelectWithFilter(p => p.MesReferencia.Equals(MesReferencia)
                && p.AnoReferencia.Equals(AnoReferencia)
                && p.IdUsuario == IdUsuario).FirstOrDefault();
        }

        public bool ExistePlanejamentoComMesEAno(Guid IdUsuario, int MesReferencia, int AnoReferencia)
        {
            return planejamentoRepository.Exist(p => p.MesReferencia.Equals(MesReferencia)
                && p.AnoReferencia.Equals(AnoReferencia)
                && p.IdUsuario == IdUsuario);
        }

    }
}
