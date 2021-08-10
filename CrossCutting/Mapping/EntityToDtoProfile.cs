using AutoMapper;
using Domain.DTO.Login;
using Domain.Entities;

namespace CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserEntity, LoginResponseDTO>().ReverseMap();
            CreateMap<UserEntity, UserRegisterRequestDTO>().ReverseMap();
        }
        
    }
}
