using CapturaPokemon.Interface;
using CapturaPokemon.Utils;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace CapturaPokemon.Service
{
    public class PokemonService : IPokemonService
    {
        public static List<Pokemon>? ListaPokemon;
      
         public static List<Pokemon> GetInstance()
        {
            if (ListaPokemon == null)
            {
                ListaPokemon = new List<Pokemon>();
            }
            return ListaPokemon;
        }

        public async Task<Pokemon> GetPokemon()
        {
            List<Pokemon> lista = GetInstance();
           
            //Seleccionar un Pokémon aleatorio de la lista
            Random rnd = new Random();

            //Obtener los detalles del Pokémon seleccionado
            var pokemonDetalles = await HttpJsonClient<PokemonAPI>.Get(Constants.POKE_URL + rnd.Next(1,500));

            if (pokemonDetalles == null)
            {
                return null;  //Si no se puede obtener los detalles del Pokémon, devolver null
            }

            //Crear un objeto Pokémon con la información obtenida
            var pokemonPropio = new Pokemon
            {
                ImagePath = pokemonDetalles?.Sprites?.Front_default,
                PokemonName = pokemonDetalles?.Name,
                PokeAtaque = pokemonDetalles?.ListaStats?.FirstOrDefault(x => x.Stat?.Name == Constants.ATTACK)?.Base_stat,
                PokeHp = pokemonDetalles?.ListaStats?.FirstOrDefault(x => x.Stat?.Name == Constants.HP)?.Base_stat,
                Captura = null
            };


            // Añadir a la lista de Pokémon
            ListaPokemon?.Add(pokemonPropio);

            // Devolver el Pokémon creado
            return pokemonPropio;
        }


        public async Task<List<Pokemon>> ProcesarPokemons()
        {
            // Return the list wrapped in a Task
            return await Task.FromResult(ListaPokemon ?? new List<Pokemon>());
        }
    }
}






