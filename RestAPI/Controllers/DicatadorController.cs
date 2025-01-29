
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ferraro.Models.DTOs.DictadorDto;
using Ferraro.Controllers.RestAPI.Controllers;
using Ferraro.Models.Entity;
using Ferraro.Repository.IRepository;
using AutoMapper;

namespace Ferraro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicatadorController : BaseController<DicatadorEntity, DicatadorDto, CreateDicatadorDto>
    {
     
            public DicatadorController(IDictadorRepository dictadorRepository,
                IMapper mapper, ILogger<IDictadorRepository> logger)
                : base(dictadorRepository, mapper, logger)
            {

            }
    }
}

