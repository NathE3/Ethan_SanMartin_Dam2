using GestionArchivos.Interface;
using GestionArchivos.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GestionArchivos.Service
{
    public class RecorrerCarpetaService : IRecorrerCarpeta
    {
        public List<DatosCarpetasArchivos> ProcesarCarpeta(string path)
        {
            string nuevaCarpeta;
            string archivo1;
            string archivo2;
            var datosCarpetasArchivos = new List<DatosCarpetasArchivos>();

            try
            {
                // Verifica si la carpeta existe, si no, la crea y los archivos dentro
                if (!Directory.Exists(path))
                {
                    // Crear la carpeta principal
                    Directory.CreateDirectory(path);
                    nuevaCarpeta = Path.Combine(path, "nuevaCarpeta");
                    Directory.CreateDirectory(nuevaCarpeta);

                    archivo1 = Path.Combine(path, "archivo1.txt");
                    archivo2 = Path.Combine(path, "archivo2.txt");

                    // Crear los archivos y escribir contenido
                    using (StreamWriter wr = new StreamWriter(archivo1))
                    {
                        wr.WriteLine("Este es el contenido del archivo 1");
                    }
                    using (StreamWriter wr2 = new StreamWriter(archivo2))
                    {
                        wr2.WriteLine("Este es el contenido del archivo 2");
                    }

                    // Agregar los datos a la lista
                    datosCarpetasArchivos.Add(new DatosCarpetasArchivos { Nombre = "nuevaCarpeta", Ruta = nuevaCarpeta, EsCarpeta = true });
                    datosCarpetasArchivos.Add(new DatosCarpetasArchivos { Nombre = "archivo1.txt", Ruta = archivo1, EsCarpeta = false });
                    datosCarpetasArchivos.Add(new DatosCarpetasArchivos { Nombre = "archivo2.txt", Ruta = archivo2, EsCarpeta = false });
                }
                else
                {
                    // Si la carpeta ya existe, procesar sus archivos y carpetas
                    string[] archivos = Directory.GetFileSystemEntries(path);
                    foreach (var archivo in archivos)
                    {
                      
                     // Si es un archivo o carpeta, agregar a la lista
                     datosCarpetasArchivos.Add(new DatosCarpetasArchivos { Nombre = Path.GetFileName(archivo), Ruta = archivo, EsCarpeta = Directory.Exists(archivo)});
                        
                    }
                }
            }
            catch (StackOverflowException e)
            {
                MessageBox.Show($"Error a la hora de crear carpetas y archivos: {e.Message}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error inesperado: {e.Message}");
            }

            return datosCarpetasArchivos;
        }
    }
}






