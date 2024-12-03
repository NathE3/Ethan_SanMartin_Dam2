using CapturaPokemon.Interface;
using CapturaPokemon.Utils;
using CapturaPokemon.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Net.Http;

namespace CapturaPokemon.Service
{
    public class PokemonService : IPokemonService
    {
        Pokemon? PokemonActual { get; set; }
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
            Random rnd = new Random();

            //Obtener los detalles del Pokémon seleccionado de al Api de forma aleatoria
            PokemonAPI pokemonDetalles = await HttpJsonClient<PokemonAPI>.Get(Constants.POKE_URL + rnd.Next(1, 101));

            if (pokemonDetalles == null)
            {
                return null;
            }

            string? pokemonImage = pokemonDetalles?.Sprites?.Front_default;
            bool esShiny = false;
            Random pokemonShiny = new Random();
            if (pokemonShiny.Next(100) < 5) // 5% de probabilidad
            {
                pokemonImage = pokemonDetalles?.Sprites?.Front_shiny;
                esShiny = true;
            }

            return CrearPokemon(pokemonDetalles, pokemonImage, esShiny);
        }

        private static Pokemon CrearPokemon(PokemonAPI pokemonDetalles, string? pokemonImage, bool esShiny)
        {
            //Crear un objeto Pokémon con la información obtenida
            var pokemonPropio = new Pokemon
            {
                Id = pokemonDetalles.Id,
                ImagePath = pokemonImage,
                PokemonName = pokemonDetalles?.Name,
                PokeAtaque = (int)(pokemonDetalles.ListaStats?.FirstOrDefault(x => x.Stat.Name == Constants.ATTACK).Base_stat),
                PokeHp = pokemonDetalles?.ListaStats?.FirstOrDefault(x => x.Stat?.Name == Constants.HP)?.Base_stat,
                Captura = esShiny
            };

            ListaPokemon?.Add(pokemonPropio);
            return pokemonPropio;
        }

        public async Task<List<Pokemon>> ProcesarPokemons()
        {
            // Retornar Lista asyncronamente
            return await Task.FromResult(ListaPokemon ?? new List<Pokemon>());
        }
    }
}






