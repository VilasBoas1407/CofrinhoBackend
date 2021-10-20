using AutoMapper;
using Domain.DTO.Planejamento;
using Domain.Entities.Planejamento;
using Domain.Interfaces;
using Domain.Repository.Planejamento;
using Domain.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Service.Planejamento
{
    public class PlanejamentoDespesaService : IPlanejamentoDespesaService
    {
        private readonly IMapper mapper;
        private IPlanejamentoDespesaRepository planejamentoDespesaRepository;

        public PlanejamentoDespesaService(IMapper _mapper, IPlanejamentoDespesaRepository _planejamentoDespesaRepository)
        {
            mapper = _mapper;
            planejamentoDespesaRepository = _planejamentoDespesaRepository;
        }

        public async Task<Response> DoRegisterAsync(PlanejamentoDespesaDTO register)
        {
            try
            {
                PlanejamentoDespesasEntity planejamentoDespesas = mapper.Map<PlanejamentoDespesasEntity>(register);

                var result = await planejamentoDespesaRepository.InsertAsync(planejamentoDespesas);

                if (result != null)
                {
                    return new Response(201, result);
                }
                else
                {
                    return new Response(400, "Erro ao cadastrar planejamento!");
                }
         
            }
            catch (Exception ex)
            {
                return new Response((int)HttpStatusCode.BadRequest, "Ocorreu um erro ao realizar o cadastro:" + ex.Message);
            }

        }
    }
}
