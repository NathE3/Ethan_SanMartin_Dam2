using MiAPIPokemon.DTO;

using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        private readonly ILogger<PokemonDTO> _logger;

        private static List<PokemonDTO> Pokemons = new List<PokemonDTO>();
      

        public PokemonController(ILogger<PokemonDTO> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllElement")]
        public IEnumerable<PokemonDTO> Get()
        {
            return Pokemons;
        }

        [HttpGet("{id}")]
        public PokemonDTO GetOne(int id)
        {
            return Pokemons.FirstOrDefault(x=>x.Id == id);
        }

        [HttpPost]
        public PokemonDTO Post([FromBody] PokemonDTO pokemon)
        {
            if (Pokemons.Any(x=> x.Id== pokemon.Id))
            {
                return null;
            }
            Pokemons.Add(pokemon);
            return pokemon;
        }

        [HttpPut("{id}")]
        public PokemonDTO Put([FromBody] PokemonDTO pokemon,int id)
        {
            if (id != pokemon?.Id)
            {
                return null;
            }
            PokemonDTO? PokemonBBDD = Pokemons.FirstOrDefault(x => x.Id == pokemon.Id);
            if (PokemonBBDD == null)
            {
                return null;
            }
            PokemonBBDD.Id = id;    
            PokemonBBDD.DateStart = pokemon.DateStart;
            PokemonBBDD.DateEnd = pokemon.DateEnd;
            PokemonBBDD.DamageDoneTrainer = pokemon.DamageDoneTrainer; 
            PokemonBBDD.DamageReceivedTrainer = pokemon.DamageReceivedTrainer;
            PokemonBBDD.DamageDonePokemon = pokemon.DamageDonePokemon;
            PokemonBBDD.PokeImagen = pokemon.PokeImagen;
            PokemonBBDD.Capturado = pokemon.Capturado;
            PokemonBBDD.Shiny = pokemon.Shiny;
            return PokemonBBDD;
        }

        [HttpDelete("{id}")]
        public bool Remove(int id)
        {
            PokemonDTO? PokemonBBDD = Pokemons.FirstOrDefault(x => x.Id == id);
            if (PokemonBBDD == null)
            {
                return false;
            }            
            return Pokemons.Remove(PokemonBBDD);
        }
    }


}
