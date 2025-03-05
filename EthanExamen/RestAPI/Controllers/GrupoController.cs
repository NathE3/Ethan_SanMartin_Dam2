using AutoMapper;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs.DictadorDto;
using RestAPI.Models.DTOs.GrupoDto;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    public class GrupoController : BaseController<GrupoEntity, GrupoDto, CreateGrupoDto>
    {

        public GrupoController(IGrupoRepository grupoRepository,
            IMapper mapper, ILogger<IDictadorRepository> logger)
            : base(grupoRepository, mapper, logger)
        {

        }
    }
}
