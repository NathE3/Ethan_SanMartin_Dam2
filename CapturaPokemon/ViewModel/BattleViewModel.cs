using CommunityToolkit.Mvvm.Input;
using CapturaPokemon.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CapturaPokemon.Models;
using CapturaPokemon.Utils;
using CapturaPokemon.Service;
using System.Windows;


namespace CapturaPokemon.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        //Importante crear la inyeccion de servicios
        private readonly IPokemonService _pokemonService;
        private readonly IPokemonServiceToApi _pokemonServiceToApi;

        string dateStart;
        string dateEnd;
        int damageDoneTrainer;
        int damageReceivedTrainer;
        int? damageDonePokemon;

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
                dateStart = DateTime.Now.ToString("O");
            }
        }

        public override async Task LoadAsync()
        {
            await CrearPokemon();
            await base.LoadAsync();
        }

        [RelayCommand]
        public async Task Huir_Click(object? parameter)
        {
            await AñadirPokemonApi();
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
        public async Task Attack_Click(object? parameter)
        {
            if (Pokemon != null)
            {
                AtacarPokemon(); // Calcula y actualiza daño hecho al Pokémon

                if (Pokemon.PokeHp > 0)
                {
                    // Si el Pokémon aún tiene vida, realiza su ataque
                    int ataquePokemon = Pokemon.PokeAtaque;
                    damageReceivedTrainer += ataquePokemon; 
                    damageDonePokemon += ataquePokemon;
                    VidaActual -= ataquePokemon; // Reduce vida del entrenador
                    VidaPorcentaje = CalcularVidaPorcentaje(VidaActual, VidaUsuario); // Actualiza porcentaje de vida
                }

                if (Pokemon.PokeHp <= 0)
                {
                    // Si el Pokémon es derrotado
                    damageDonePokemon = Constants.VIDAMAXIMA - (Pokemon.PokeAtaque + VidaActual);
                    dateEnd = DateTime.Now.ToString("O"); // Registra el tiempo final
                    await AñadirPokemonApi(); // Añade Pokémon derrotado a la API                                                             
                    damageReceivedTrainer = 0; // Resetea daño recibido (nuevo combate)
                    damageDonePokemon = 0;
                    await NuevoPokemon(); // Genera un nuevo Pokémon
                }
                if (VidaActual <= 0) 
                    {
                    MessageBox.Show("Game over pringado");
                    Application.Current.Shutdown();
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

        public async Task CaputuraExitosaOno(int vidaRestantePorcentaje, int resultado)
        {
            if (resultado > vidaRestantePorcentaje)
            {
                // El Pokémon ha sido capturado 
                if (Pokemon.Shiny)
                {
                    // Si el Pokémon es shiny, restaura la vida del entrenador a máxima
                    VidaActual = Constants.VIDAMAXIMA;
                    VidaPorcentaje = CalcularVidaPorcentaje(VidaActual, VidaUsuario);
                    Pokemon.Captura = true;
                    Pokemon.Shiny = true;
                }
                else
                {
                    // Incrementa un 5% de la vida máxima del entrenador 
                    VidaActual = Math.Min(Constants.VIDAMAXIMA, (int)(VidaActual + (Constants.VIDAMAXIMA * 5 / 100)));
                    VidaPorcentaje = CalcularVidaPorcentaje(VidaActual, VidaUsuario);
                    Pokemon.Captura = true;
                }
                        
                // Añade el Pokémon capturado a la API
                await AñadirPokemonApi();

                // Genera un nuevo Pokémon
                await NuevoPokemon();
            }
        }

        private async Task AñadirPokemonApi()
        {
            try
            {
                var pokemon = CreatePoke();
                await _pokemonServiceToApi.AddPokemonToApi(pokemon);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AtacarPokemon()
        {
            Random rn = new Random();
            int ataqueUsuario = rn.Next(0, 60); 
            damageDoneTrainer += ataqueUsuario; 
            int vidaPokemon = Pokemon.PokeHp - ataqueUsuario;
            if (vidaPokemon > 0)
            {
                Pokemon.PokeHp = vidaPokemon;
            }
            else
            {
                Pokemon.PokeHp = 0; 
            }

            VidaActualPokemon = Pokemon.PokeHp;
            VidaPorcentajePokemon = CalcularVidaPorcentaje(VidaActualPokemon, VidaMaximaPokemon);
        }

        private string CalcularVidaPorcentaje(int? vida, int? vidaMax)
        {
            if (vida > 0)
            {
                return  $"{vida * 100 / vidaMax}%";
            }
            else 
            {
               return "0%";
            }
             
        }

        private PokemonDTO CreatePoke()
        {
            return new PokemonDTO
            {
                Id = _pokemonServiceToApi.GenerarIdAleatorio(),
                DateStart = dateStart,
                DateEnd = dateEnd,
                PokeName = Pokemon.PokemonName,
                DamageDoneTrainer = damageDoneTrainer,
                DamageReceivedTrainer = damageReceivedTrainer,
                DamageDonePokemon = damageDonePokemon,
                PokeImagen = Pokemon.ImagePath,
                Capturado = Pokemon.Captura ?? false,
                Shiny = Pokemon.Shiny
            };
            
        }
    }
}



