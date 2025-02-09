
using Microsoft.AspNetCore.Mvc;
using FerrariApi.Controllers.FerrariApi.Controllers;
using AutoMapper;
using FerrariAPI.Models.Entity;
using FerrariAPI.Models.DTOs.DictadorDto;
using FerrariAPI.Models.DTOs.FerrariDTO;
using FerrariAPI.Repository.IRepository;

namespace FerrariApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FerrariController : BaseController<FerrariEntity, FerrariDTO, CreateFerrariDTO>
    {
     
            public FerrariController(IFerrariRepository ferrariRepository,
                IMapper mapper, ILogger<IFerrariRepository> logger)
                : base(ferrariRepository, mapper, logger)
            {

            }
    }
}

