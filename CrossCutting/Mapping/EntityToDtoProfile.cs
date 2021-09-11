using AutoMapper;
using Domain.DTO.Login;
using Domain.DTO.Planejamento;
using Domain.Entities;
using Domain.Entities.Planejamento;

namespace CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserEntity, LoginResponseDTO>().ReverseMap();
            CreateMap<UserEntity, UserRegisterRequestDTO>().ReverseMap();
            CreateMap<PlanejamentoEntity, PlanejamentoRegisterDTO>().ReverseMap();
            CreateMap<PlanejamentoEntity, PlanejamentoDTO>().ReverseMap();
        }
        
    }
}
