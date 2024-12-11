using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Utils
{

    public class LeerEscribirArchivo
    {
    //ESCRIBE SIN BORRAR LO ANTERIOR
        public static void Escribir(string texto, string ruta)
        {
            StreamWriter escribir = new StreamWriter(ruta, true);
            escribir.WriteLine(texto);
            escribir.Close();
        }

        //LEE TODO EL TEXTO 
        public static string Leer(string ruta)
        {
            return File.ReadAllText(ruta);
        }

    }
}
