using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Menadzeri")]
    public class Menadzer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(30)]
        public string Prezime { get; set; }

        [Required]
        [Range(35, 65)]
        public int BrojGodina { get; set; }

        public virtual TimFC Tim { get; set; }
    }
}