using FerrariAPI.Models.DTOs.DictadorDto;
using FerrariAPI.Models.DTOs.UserDto;
using AutoMapper;
using FerrariAPI.Models.Entity;
using FerrariAPI.Models.DTOs.FerrariDTO;
using FerrariAPI.Models.DTOs.PujaDTO;

namespace FerrariApi.AutoMapper
{
    public class ApplicationMapper : Profile
    {
    
        public ApplicationMapper()
        {
            CreateMap<FerrariEntity, FerrariDTO>().ReverseMap();
            CreateMap<FerrariEntity, CreateFerrariDTO>().ReverseMap();
            CreateMap<PujaEntity, PujaDTO>().ReverseMap();
            CreateMap<PujaEntity, CreatePujaDTO>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
