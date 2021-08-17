using AutoMapper;
using AutoMapper.Configuration;
using Domain.DTO.Planejamento;
using Domain.Entities.Planejamento;
using Domain.Interfaces;
using Domain.Repository.Planejamento;
using Domain.Utils;
using System;
using System.Threading.Tasks;

namespace Service.Planejamento
{
    public class PlanejamentoService : IPlanejamentoService
    {
        private IPlanejamentoRepository planejamentoRepository;
        private IConfiguration configuration { get; }
        private readonly IMapper mapper;
        

        public PlanejamentoService(IPlanejamentoRepository _planejamento,
            IConfiguration _configuration,
            IMapper _mapper)
        {
            mapper = _mapper;
            configuration = _configuration;
            planejamentoRepository = _planejamento;

        }

        public async Task<Response> DoRegisterAsync(PlanejamentoRegisterDTO register)
        {
            try
            {
                PlanejamentoEntity planejamento = mapper.Map<PlanejamentoEntity>(register);

                bool hasPlanejamento = planejamentoRepository.ExistAsync(p => p.MesReferencia.Equals(planejamento.MesReferencia) 
                && p.AnoReferencia.Equals(planejamento.AnoReferencia) 
                && p.IdUsuario == planejamento.IdUsuario);
                    
                if(hasPlanejamento)
                    return new Response(400, "Já existe um planejamento cadastrado nesse período.");

                var result = await planejamentoRepository.InsertAsync(planejamento);

                if (result != null)
                    return new Response(201, "Planejamento cadastrado com sucesso!");
                else
                    return new Response(400, "Erro ao cadastrar usuário!");

            }
            catch (Exception ex)
            {
                return new Response(500, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }
        }
    }
}
