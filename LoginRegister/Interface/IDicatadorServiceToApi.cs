using LoginRegister.Models;


namespace LoginRegister.Interface
{
    public interface IDicatadorServiceToApi
    {
        // Obtiene un Dicatadores desde la API
        Task<IEnumerable<DicatadorDTO>> GetDicatadores();

        // Agrega un Dicatador a la API
        Task PostDicatador(DicatadorDTO dicatador);

        // Modifica un Dicatador ya existente
        Task PutDicatador(DicatadorDTO dicatador);
    }
}
