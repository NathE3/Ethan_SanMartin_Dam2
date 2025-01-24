
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.DTOs.DictadorDto;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;
using AutoMapper;

namespace RestAPI.Controllers
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

