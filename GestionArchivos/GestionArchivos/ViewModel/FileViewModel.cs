using CommunityToolkit.Mvvm.Input;
using GestionArchivos.Interface;
using GestionArchivos.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;


namespace GestionArchivos.ViewModel
{
    public partial class FileViewModel : ViewModelBase
    {
        //Importante crear la inyeccion de servicios
        private readonly IRecorrerCarpeta _recorrerCarpeta;

        //importante crearla ObservableCollection para que se actualice nada mas crearlo 
        public ObservableCollection<DatosCarpetasArchivos> Item { get; set; }

        //meterla en el contructor para poder utilizarla en el FileViewModel, hay que meterlo en la App y ademas pasarlo como parametro.
        public FileViewModel(IRecorrerCarpeta recorrerCarpeta)
        {
            _recorrerCarpeta = recorrerCarpeta;
            Item = new ObservableCollection<DatosCarpetasArchivos>();
            CargarDatos();
        }

        
        private void CargarDatos()
        {
            // Obtener la ruta del proyecto,  carpeta bin
            string carpetaProyectoRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,Constants.RAIZ));

            // crear o acceder a los archivos en carpeta "pruebaClase"
            string carpetaDestino = Path.Combine(carpetaProyectoRaiz, "pruebaClase");

            try
            {
                var datos = _recorrerCarpeta.ProcesarCarpeta(carpetaDestino); 

                // Llenar la colección Item con los datos
                foreach (var dato in datos)
                {
                    Item.Add(dato);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear archivo o cargar datos: {ex.Message}");
            }
        }

        //Crear el archivo y mostrarlo
        [RelayCommand]
        private void Archivo(object parameter) 
            {
                string fileName = PromptForName("Introduce el nombre de tu archivo:");
                if (!string.IsNullOrWhiteSpace(fileName)) 
                    {
                string folderPath = Path.Combine(Constants.PATH, fileName+".txt");
                File.Create(folderPath).Close();
                Item.Add(new DatosCarpetasArchivos(fileName,Constants.PATH, false, Constants.ICONO_ARCHIVO));
                
                    }
            }

        //Creando directorio y mostrandolo
        [RelayCommand]
        private void Directorio(object parameter)
        {
            string folderName = PromptForName("Introduce el nombre de tu archivo:");
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                string folderPath = Path.Combine(Constants.PATH, folderName);
                Directory.CreateDirectory(Constants.PATH);
                Item.Add(new DatosCarpetasArchivos(folderName, Constants.PATH, true, Constants.ICONO_CARPETA));
            }
        }


        //PopUp para sacar el creador de archivo o directorio
        private string PromptForName(string message)
            {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Creando archivo o directorio", "");
            }
    }
}



