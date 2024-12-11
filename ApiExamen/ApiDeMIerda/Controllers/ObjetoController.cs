using ApiExamen.DTO;

using Microsoft.AspNetCore.Mvc;

namespace ApiExamen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjetoController : Controller
    {
        private readonly ILogger<ObjetoDTO> _logger;

        private static List<ObjetoDTO> Objetos = new List<ObjetoDTO>();
      

        public ObjetoController(ILogger<ObjetoDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<ObjetoDTO> Get()
        {
            return Objetos;
        }

        [HttpGet("{id}")]
        public ObjetoDTO GetOne(Guid id)
        {
            return Objetos.FirstOrDefault(x=>x.Id == id);
        }

        [HttpPost]
        public ObjetoDTO Post([FromBody] ObjetoDTO objeto)
        {
            if (Objetos.Any(x=> x.Id== objeto.Id))
            {
                return null;
            }
            Objetos.Add(objeto);
            return objeto;
        }

        [HttpPut("{id}")]
        public ObjetoDTO Put([FromBody] ObjetoDTO objeto, Guid id)
        {
            if (id != objeto?.Id)
            {
                return null;
            }
            ObjetoDTO? ObjetoBBDD = Objetos.FirstOrDefault(x => x.Id == objeto.Id);
            if (ObjetoBBDD == null)
            {
                return null;
            }
            ObjetoBBDD.Id = id;
            ObjetoBBDD.DateStart = objeto.DateStart;
            ObjetoBBDD.DateEnd = objeto.DateEnd;
            ObjetoBBDD.DamageDoneTrainer = objeto.DamageDoneTrainer;
            ObjetoBBDD.DamageReceivedTrainer = objeto.DamageReceivedTrainer;
            ObjetoBBDD.DamageDonePokemon = objeto.DamageDonePokemon;
            ObjetoBBDD.PokeImagen = objeto.PokeImagen;
            ObjetoBBDD.Capturado = objeto.Capturado;
            ObjetoBBDD.Shiny = objeto.Shiny;
            return ObjetoBBDD;
        }

        [HttpDelete("{id}")]
        public bool Remove(Guid id)
        {
            ObjetoDTO? ObjetoBBDD = Objetos.FirstOrDefault(x => x.Id == id);
            if (ObjetoBBDD == null)
            {
                return false;
            }            
            return Objetos.Remove(ObjetoBBDD);
        }


        [HttpDelete("deleteAll")]
        public IActionResult DeleteAll()
        {
            if (Objetos.Count == 0)
            {
                return NoContent();
            }

            Objetos.Clear();
            return Ok("Todos los pokemons han borrados");
        }

    }


}
