

using CommunityToolkit.Mvvm.ComponentModel;

namespace CapturaPokemon.Models
{
    public class PokemonsTeam 
    {
        public string PokeName { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public bool Shiny { get; set; }
        public bool Capturado { get; set; }
      
    }
}
