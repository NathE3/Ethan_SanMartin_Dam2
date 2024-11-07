using CommunityToolkit.Mvvm.Input;
using GestionArchivos.Interface;
using GestionArchivos.Service;
using GestionArchivos.Utils;
using GestionArchivos.View;
using GestionArchivos.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GestionArchivos.ViewModel
{
    public partial class FileViewModel : ViewModelBase
    {
        //importante crearla ObservableCollection para que se actualice nada mas crearlo 
        public ObservableCollection<DatosCarpetasArchivos> Item { get; set; }

        //meterla en el contructor para poder utilizarla en el FileViewModel
        public FileViewModel()
        {
            Item = new ObservableCollection<DatosCarpetasArchivos>();
            CargarDatos();
        }

        
        private void CargarDatos()
        {
            // Obtener la ruta del proyecto,  carpeta bin
            string carpetaProyectoRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));

            // crear o acceder a los archivos en carpeta "pruebaClase"
            string carpetaDestino = Path.Combine(carpetaProyectoRaiz, "pruebaClase");

            try
            {
              
                var service = new RecorrerCarpetaService();
                var datos = service.ProcesarCarpeta(carpetaDestino); 

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
                string folderPath = Path.Combine(@"..\..\pruebaClase", fileName+".txt");
                File.Create(folderPath).Close();
                Item.Add(new DatosCarpetasArchivos(fileName, @"..\..\pruebaClase", false));
                
                    }
            }

        //Creando directorio y mostrandolo
        [RelayCommand]
        private void Directorio(object parameter)
        {
            string folderName = PromptForName("Introduce el nombre de tu archivo:");
            if (!string.IsNullOrWhiteSpace(folderName))
            {
                string folderPath = Path.Combine(@"..\..\pruebaClase", folderName);
                Directory.CreateDirectory(@"..\..\pruebaClase");
                Item.Add(new DatosCarpetasArchivos(folderName, @"..\..\pruebaClase",true));
            }
        }


        //PopUp para sacar el creador de archivo o directorio
        private string PromptForName(string message)
            {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Creando archivo o directorio", "");
            }
    }
}



