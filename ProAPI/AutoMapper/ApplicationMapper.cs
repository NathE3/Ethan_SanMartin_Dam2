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
            CreateMap<DictadorEntity, DicatadorDto>().ReverseMap();
            CreateMap<DictadorEntity, CreateDicatadorDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
