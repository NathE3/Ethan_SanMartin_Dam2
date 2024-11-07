using GestionArchivos.Interface; 

namespace GestionArchivos.Utils
{
    public class DatosCarpetasArchivos 
    {
        public DatosCarpetasArchivos(string nombre,string ruta,bool esCarpeta) 
        {
            Nombre = nombre;
            Ruta = ruta;
            EsCarpeta = esCarpeta;
        }

        public DatosCarpetasArchivos()
        {
        }

        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public bool EsCarpeta { get; set; }
    }
}