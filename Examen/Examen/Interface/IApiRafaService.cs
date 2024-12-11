using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Interface
{
    public interface IApiRafaService
    {
        Task<List<MiObjeto>> ProcesarObjeto();
        Task<MiObjeto> GetObjeto();
    }
}
