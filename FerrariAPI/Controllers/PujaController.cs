
using Microsoft.AspNetCore.Mvc;
using FerrariApi.Controllers.FerrariApi.Controllers;
using AutoMapper;
using FerrariAPI.Models.Entity;
using FerrariAPI.Repository.IRepository;
using FerrariAPI.Models.DTOs.PujaDTO;

namespace FerrariApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PujaController : BaseController<PujaEntity, PujaDTO, CreatePujaDTO>
    {

        public PujaController(IPujaRepository pujaRepository,
            IMapper mapper, ILogger<IPujaRepository> logger)
            : base(pujaRepository, mapper, logger)
        {

        }
    }
}