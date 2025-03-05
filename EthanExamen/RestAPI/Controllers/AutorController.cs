using AutoMapper;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs.AutorDto;
using RestAPI.Models.DTOs.GrupoDto;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    public class AutorController : BaseController<AutorEntity, AutorDto, CreateAutorDto>
    {
        public AutorController(IAutorRepository autorRepository,
            IMapper mapper, ILogger<IAutorRepository> logger) 
            : base(autorRepository, mapper, logger)
        {

        }
    }
}
