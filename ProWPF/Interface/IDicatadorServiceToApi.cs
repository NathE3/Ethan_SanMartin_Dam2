﻿using ProWPF.Models;


namespace ProWPF.Interface
{
    public interface IDicatadorServiceToApi
    {
        // Obtiene un Dicatadores desde la API
       Task<DicatadorDTO> GetDicatador();

        // Agrega un Dicatador a la API
        Task PostDicatador(object dicatador);

        // Procesa y devuelve la lista de Dicatadores almacenados
        Task<List<DicatadorDTO>> GetAllDicatadores();
    }
}
