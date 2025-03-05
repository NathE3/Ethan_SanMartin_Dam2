using RestAPI.Models.DTOs.DictadorDto;
using RestAPI.Models.DTOs.UserDto;
using AutoMapper;
using RestAPI.Models.Entity;
using RestAPI.Models.DTOs.AutorDto;
using RestAPI.Models.DTOs.GrupoDto;

namespace RestAPI.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<DicatadorEntity, DicatadorDto>().ReverseMap();
            CreateMap<DicatadorEntity, CreateDicatadorDto>().ReverseMap();

            CreateMap<AutorEntity, AutorDto>().ReverseMap();
            CreateMap<AutorEntity, CreateAutorDto>().ReverseMap();

            CreateMap<GrupoEntity, GrupoDto>().ReverseMap();
            CreateMap<GrupoEntity, CreateGrupoDto>().ReverseMap();

            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
