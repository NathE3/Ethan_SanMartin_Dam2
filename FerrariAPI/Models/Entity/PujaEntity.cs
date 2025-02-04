using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FerrariAPI.Models.Entity
{
    public class PujaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double Puja { get; set; }

        [Required]
        public string Name { get; set; }    

        [Required]

        public int Id_ferrari { get; set; }


    }
}
