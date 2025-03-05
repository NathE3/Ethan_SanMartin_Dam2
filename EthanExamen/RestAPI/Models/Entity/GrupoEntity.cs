using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Entity
{

    /*Relacion many to many con dicatadores*/
    public class GrupoEntity
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

        public List<DicatadorEntity> Dicatadores { get; set; }
    }
}
