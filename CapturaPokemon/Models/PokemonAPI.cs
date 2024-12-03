using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapturaPokemon.Models
{
    internal class PokemonAPI
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites? Sprites { get; set; }

        [JsonPropertyName("stats")]
        public List<Stats>? ListaStats { get; set; }
    
        }
    }

  
    public class Sprites
    {
    [JsonPropertyName("front_default")]
    public string? Front_default { get; set; }

    [JsonPropertyName("front_shiny")]
    public string? Front_shiny { get; set; }
}

    public class Stats
    {
        [JsonPropertyName("base_stat")]
        public int? Base_stat { get; set; }

        [JsonPropertyName("stat")]
        public Stat? Stat { get; set; }

    }

    public class Stat 
        {
    [JsonPropertyName("name")]
    public string? Name { get; set; }
        } 





