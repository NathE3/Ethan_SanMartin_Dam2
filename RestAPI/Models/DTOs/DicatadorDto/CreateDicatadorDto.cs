using System.ComponentModel.DataAnnotations;

namespace Ferraro.Models.DTOs.DictadorDto
{
    public class CreateDicatadorDto
    {
     
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "Max char is 15")]
        public string name { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string description { get; set; }


        [MaxLength(20, ErrorMessage = "Max char is 20")]
        [Required(ErrorMessage = "Pais is required")]
        public string pais { get; set; }

        public string image { get; set; }


    }
}
