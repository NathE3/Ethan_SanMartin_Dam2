
using CommunityToolkit.Mvvm.ComponentModel;

namespace CapturaPokemon.Models
{

    public class Pokemon :ObservableObject
    {
        public int Id { get; set; }
        public string? PokemonName { get; set; }

        public string? ImagePath { get; set; }

        public bool? Captura { get; set; }

        public int PokeAtaque { get; set; }

        public int? PokeHp { get; set; }

        public bool Shiny { get; set; }
    }

}