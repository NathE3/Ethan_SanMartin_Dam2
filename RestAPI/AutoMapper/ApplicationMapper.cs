using RestAPI.Models.DTOs.DictadorDto;
using RestAPI.Models.DTOs.UserDto;
using AutoMapper;
using RestAPI.Models.Entity;

namespace RestAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<DicatadorEntity, DicatadorDto>().ReverseMap();
            CreateMap<DicatadorEntity, CreateDicatadorDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
