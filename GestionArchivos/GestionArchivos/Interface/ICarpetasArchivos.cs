using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionArchivos.Interface
{
    public interface ICarpetasArchivos
    {
        string Nombre { get; set; }
        string Ruta { get; set; }
        bool EsCarpeta { get; set; }
    }
}
