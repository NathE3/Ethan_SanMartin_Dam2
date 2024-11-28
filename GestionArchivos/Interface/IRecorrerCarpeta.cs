using GestionArchivos.Utils;


namespace GestionArchivos.Interface
{
    public interface IRecorrerCarpeta
    {
        List <DatosCarpetasArchivos> ProcesarCarpeta(string nombre);
    }
}
