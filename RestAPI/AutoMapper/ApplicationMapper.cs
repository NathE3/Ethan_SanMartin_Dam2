using Ferraro.Models.DTOs.DictadorDto;
using Ferraro.Models.DTOs.UserDto;
using AutoMapper;
using Ferraro.Models.Entity;

namespace Ferraro.AutoMapper
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
