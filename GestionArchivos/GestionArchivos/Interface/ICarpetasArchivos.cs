
namespace GestionArchivos.Interface
{
    public interface ICarpetasArchivos
    {
        string Nombre { get; set; }
        string Ruta { get; set; }
        bool EsCarpeta { get; set; }
    }
}
