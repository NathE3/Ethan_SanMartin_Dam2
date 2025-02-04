using System.ComponentModel.DataAnnotations;

namespace FerrariAPI.Models.DTOs.PujaDTO
{
    public class CreatePujaDTO
    {
        [Required(ErrorMessage = "Puja is required")]
        double Puja;

        [Required(ErrorMessage = "Name usuario is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Id_Ferrari usuario is required")]
        public int Id_ferrari { get; set; }
    }
}
