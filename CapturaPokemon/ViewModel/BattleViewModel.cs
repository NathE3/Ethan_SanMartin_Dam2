using CommunityToolkit.Mvvm.Input;
using CapturaPokemon.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CapturaPokemon.Models;
using CapturaPokemon.Utils;
using CapturaPokemon.Service;


namespace CapturaPokemon.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        //Importante crear la inyeccion de servicios
        private readonly IPokemonService _pokemonService;
        private readonly IPokemonServiceToApi _pokemonServiceToApi;

        DateTime dateStart;
        DateTime dateEnd;
        int damageDoneTrainer;
        int damageReceivedTrainer;
        int damageDonePokemon;

        [ObservableProperty]
        private int? _VidaUsuario = Constants.VIDAMAXIMA;

        [ObservableProperty]
        private int? _VidaActual;

        [ObservableProperty]
        public string? _VidaPorcentaje;

        [ObservableProperty]
        public string? _VidaPorcentajePokemon;

        [ObservableProperty]
        public int? _VidaActualPokemon;

        [ObservableProperty]
        public int? _VidaMaximaPokemon;


        private Pokemon? _pokemon;
        public Pokemon? Pokemon
        {
            get => _pokemon;
            set => SetProperty(ref _pokemon, value);
        }



        public BattleViewModel(IPokemonService pokemonService, IPokemonServiceToApi pokemonServiceToApi)
        {
            _pokemonService = pokemonService;
            _pokemonServiceToApi = pokemonServiceToApi;
            VidaActual = VidaUsuario;
            VidaPorcentaje = CalcularVidaPorcentaje(VidaActual, VidaUsuario);
        }

        public async Task CrearPokemon()
        {
           
            if (Pokemon == null) 
            { 
             Pokemon = await _pokemonService.GetPokemon();

                if (Pokemon.PokeHp != null)
                {
                    AsirgnarVidaPokemon();
                }
                dateStart = DateTime.Now;
            }
        }

        public override async Task LoadAsync()
        {
            await CrearPokemon();
            await base.LoadAsync();
        }

        [RelayCommand]
        private async Task Huir_Click(object? parameter)
        {

            Pokemon = await _pokemonService.GetPokemon();
            if (Pokemon.PokeHp != null)
            {
                AsirgnarVidaPokemon();
            }
        }

        private void AsirgnarVidaPokemon()
        {
            VidaActualPokemon = Pokemon.PokeHp;
            VidaMaximaPokemon = Pokemon.PokeHp;
            VidaPorcentajePokemon = CalcularVidaPorcentaje(Pokemon.PokeHp, VidaMaximaPokemon);
        }

        [RelayCommand]
        private async Task Attack_Click(object? parameter) 
        {
            
            if (Pokemon != null)
            {
                AtacarPokemon();

                if (Pokemon.PokeHp > 0)
                {
                    int ataquePokemon = Pokemon.PokeAtaque;
                    damageReceivedTrainer = ataquePokemon;
                    VidaActual -= ataquePokemon;
                    VidaPorcentaje = CalcularVidaPorcentaje(VidaActual, VidaUsuario);
                }


                if (Pokemon.PokeHp <= 0)
                {
                    dateEnd = DateTime.Now;
                    AñadirPokemonApi();
                    damageReceivedTrainer = 0;
                    await NuevoPokemon();
                }
            }
        }

        private async Task NuevoPokemon()
        {
            Pokemon = await _pokemonService.GetPokemon();
            if (Pokemon.PokeHp != 0)
            {
                AsirgnarVidaPokemon();
            }
        }

        [RelayCommand]
        private async Task Captura(object? parameter)
        {
            if (Pokemon == null || VidaActualPokemon == null || VidaMaximaPokemon == null)
                return;

            // Calcula la probabilidad de captura
            int vidaRestantePorcentaje = (int)((VidaActualPokemon * 100) / VidaMaximaPokemon);
           

            Random rn = new Random();
            int resultado = rn.Next(0, 100);

            await CaputuraExitosaOno(vidaRestantePorcentaje, resultado);
        }

        private async Task CaputuraExitosaOno(int vidaRestantePorcentaje, int resultado)
        {
            if (resultado > vidaRestantePorcentaje) 
            {
              
                if (Pokemon.Shiny)
                {
                    VidaActual = Constants.VIDAMAXIMA; 
                }
                else
                {
                    VidaActual = Math.Min(Constants.VIDAMAXIMA, (int)(VidaActual + (Constants.VIDAMAXIMA * 5 / 100)));
                }

                VidaPorcentaje = CalcularVidaPorcentaje(VidaActual, VidaUsuario);

                // Añade el Pokémon a la API
                await AñadirPokemonApi();

                // Genera un nuevo Pokémon
                await NuevoPokemon();
            }
        }

        private async Task AñadirPokemonApi()
        {
            try
            {
                PokemonDTO pokemon = _pokemonServiceToApi.ConvertirDTO(Pokemon, dateStart,dateEnd, damageDoneTrainer, damageReceivedTrainer, damageDonePokemon);
                await _pokemonServiceToApi.AddPokemonToApi(pokemon);
            }
            catch (Exception ex)
            {
 
            }
        }

        private void AtacarPokemon()
        {
            Random rn = new Random();
            int ataqueUsuario = rn.Next(0, 60);
            damageDoneTrainer += ataqueUsuario;
            int? vidaPokemon = Pokemon.PokeHp - ataqueUsuario;

            if (vidaPokemon > 0)
            {
                Pokemon.PokeHp = vidaPokemon;
            }
            else
            {
                damageDoneTrainer = 0;
                Pokemon.PokeHp = 0;
            }

            VidaActualPokemon = Pokemon.PokeHp;

            VidaPorcentajePokemon = CalcularVidaPorcentaje(VidaActualPokemon, VidaMaximaPokemon);
        }

        private string CalcularVidaPorcentaje(int? vida, int? vidaMax)
        {
            if (vida != 0)
            {
                return  $"{vida * 100 / vidaMax}%";
            }
            else 
            {
               return "0%";
            }
             
        }
    }
}



