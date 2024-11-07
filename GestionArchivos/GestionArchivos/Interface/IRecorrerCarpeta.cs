using GestionArchivos.Utils;
using GestionArchivos.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionArchivos.Interface
{
    public interface IRecorrerCarpeta
    {
        List <DatosCarpetasArchivos> ProcesarCarpeta(string nombre);
    }
}
