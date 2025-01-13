using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.DictadorDto
{
    public class CreateDictadorDto
    {
     
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "Max char is 15")]

        public string name { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Description { get; set; }

        [MaxLength(20, ErrorMessage = "Max char is 20")]
        [Required(ErrorMessage = "Name is required")]
        public string Pais { get; set; }
    }
}
