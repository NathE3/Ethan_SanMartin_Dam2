using GestionArchivos.Interface; 

namespace GestionArchivos.Utils
{
    public class DatosCarpetasArchivos 
    {
        public DatosCarpetasArchivos(string nombre,string ruta,bool esCarpeta, string imagen) 
        {
            Nombre = nombre;
            Ruta = ruta;
            EsCarpeta = esCarpeta;
            Imagen = imagen;
        }

        public DatosCarpetasArchivos()
        {
        }

        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public bool EsCarpeta { get; set; }
        public string Imagen { get; set; }
    }
}