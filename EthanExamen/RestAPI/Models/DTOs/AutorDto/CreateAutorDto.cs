using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.DTOs.AutorDto
{
    public class CreateAutorDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "Max char is 15")]
        public string name { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string description { get; set; }

        public int id_dicatador { get; set; }

    }
}
