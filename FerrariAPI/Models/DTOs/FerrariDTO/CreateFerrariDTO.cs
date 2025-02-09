using System.ComponentModel.DataAnnotations;

namespace FerrariAPI.Models.DTOs.FerrariDTO

{
    public class CreateFerrariDTO
    {

        [Required(ErrorMessage = "Imagen is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]   
        public string Description { get; set; }

        [Required(ErrorMessage = "Año salida  is required")]
        public string AnoSalida { get; set; }

        [Required(ErrorMessage = "Puja actual is required")]
        public string Cv { get; set; }

        [Required(ErrorMessage = "Puja actual is required")]
        public string PrecioEstimado { get; set; }

        [Required(ErrorMessage = "Puja actual is required")]
        public string PujaInicial { get; set; }
    }
}
