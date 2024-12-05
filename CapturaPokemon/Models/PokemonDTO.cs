using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapturaPokemon.Models
{
    public class PokemonDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dateStart")]
        public string DateStart { get; set; }

        [JsonPropertyName("dateEnd")]
        public string DateEnd { get; set; }

        [JsonPropertyName("pokeName")]
        public string? PokeName { get; set; }

        [JsonPropertyName("damageDoneTrainer")]
        public int DamageDoneTrainer { get; set; }

        [JsonPropertyName("damageReceivedTrainer")]
        public int? DamageReceivedTrainer { get;set; }

        [JsonPropertyName("damageDonePokemon")]
        public int? DamageDonePokemon { get;set; }

        [JsonPropertyName("pokeImagen")]
        public string? PokeImagen { get; set; }

        [JsonPropertyName("capturado")]
        public bool? Capturado { get; set; }

        [JsonPropertyName("shiny")]
        public bool Shiny { get; set; }



    }
}
