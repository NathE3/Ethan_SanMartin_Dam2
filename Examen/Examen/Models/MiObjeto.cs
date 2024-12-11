using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class MiObjeto : ObservableObject
    {
        public Guid Id { get; set; }
        public string? PokemonName { get; set; }

        public string? ImagePath { get; set; }

        public bool? Captura { get; set; }

        public int PokeAtaque { get; set; }

        public int PokeHp { get; set; }

        public bool Shiny { get; set; }

        public int DamageDoneTrainer { get; private set; }

        public int? DamageReceivedTrainer { get; private set; }

        public int DamageDonePokemon { get; private set; }
    }
}
