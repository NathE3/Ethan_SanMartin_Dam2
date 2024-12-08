using CapturaPokemon.Interface;
using CapturaPokemon.Models;
using CapturaPokemon.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace CapturaPokemon.ViewModel
{
    public partial class TeamViewModel : ViewModelBase
    {

       
        public TeamViewModel()
        {
            listaPokemons = new ObservableCollection<PokemonsTeam>();
        }


        [ObservableProperty]
        private ObservableCollection<PokemonsTeam> listaPokemons;

        public override async Task LoadAsync()
        {
            List<PokemonDTO> listaPokemon = await HttpJsonClient<List<PokemonDTO>>.Get(Constants.POKEUS_URL);
            if (listaPokemon != null)
            {
                     var pokemonList = listaPokemon
                    .Where(p => !string.IsNullOrEmpty(p.PokeName) && p.Capturado)
                    .GroupBy(p => p.PokeName)
                    .Select(g => new PokemonsTeam
                    {
                        PokeName = g.Key,
                        Image = g.FirstOrDefault(p => p.Shiny)?.PokeImagen ?? g.First().PokeImagen,
                        Shiny = g.First().Shiny,
                        Count = g.Count(),
                        Capturado = true
                    })
                    .ToList();
                ListaPokemons.Clear();
            try
            {
              
                foreach (var poke in pokemonList)
                {
                    
                  listaPokemons.Add(poke);
               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        }

    }
}

