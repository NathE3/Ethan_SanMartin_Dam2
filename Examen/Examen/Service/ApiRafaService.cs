using Examen.Models;
using Examen.Utils;
using Examen.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Service
{

    public class ApiRafaService : IApiRafaService
    {
        MiObjeto? ObjetoActual { get; set; }
    
        public static List<MiObjeto>? ListaObjeto;

         public static List<MiObjeto> GetInstance()
         {
            if (ListaObjeto == null)
            {
                ListaObjeto = new List<MiObjeto>();
             }
                return ListaObjeto;
         }

         public async Task<MiObjeto> GetObjeto()
         {
             List<MiObjeto> lista = GetInstance();
             Random rnd = new Random();

             //Obtener los detalles del Objeto seleccionado de al Api de forma aleatoria
             ObjetoRafa objetoDetalles = await HttpJsonClient<ObjetoRafa>.Get(Constants.API_URL + rnd.Next(1, 100));

             if (objetoDetalles == null)
             {
                 return null;
             }

            string? pokemonImage = objetoDetalles?.Sprites?.Front_default;
            bool esShiny = false;
            Random pokemonShiny = new Random();

            if (pokemonShiny.Next(100) < 5) // 5% de probabilidad
            {
                pokemonImage = objetoDetalles?.Sprites?.Front_shiny;
                esShiny = true;
            }

            return CrearObjeto(objetoDetalles, pokemonImage, esShiny);
         }

        private static MiObjeto CrearObjeto(ObjetoRafa objetoDetalles, string? pokemonImage, bool esShiny)
        {
             //Crear un objeto Pokémon con la información obtenida
             var objetoPropio = new MiObjeto
             {
                Id = objetoDetalles.Id,
                ImagePath = pokemonImage,
                PokemonName = objetoDetalles?.Name,
                PokeAtaque = (int)(objetoDetalles.ListaStats?.FirstOrDefault(x => x.Stat.Name == Constants.ATTACK).Base_stat),
                PokeHp = (int)(objetoDetalles.ListaStats.FirstOrDefault(x => x.Stat?.Name == Constants.HP).Base_stat),
                Captura = false,
                Shiny = esShiny,
             };

                ListaObjeto?.Add(objetoPropio);
                return objetoPropio;
        }

        public async Task<List<MiObjeto>> ProcesarObjeto()
        {
            // Retornar Lista asyncronamente
            return await Task.FromResult(ListaObjeto ?? new List<MiObjeto>());
        }
    }
}

