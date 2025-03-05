using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestAPI.Models.DTOs.DictadorDto;

namespace RestAPI.Models.Entity
{
    /*Relacion one to many con dicatadores*/
    public class AutorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }


        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public ICollection<DicatadorEntity> Dicatador { get; } = [];
    }
}
