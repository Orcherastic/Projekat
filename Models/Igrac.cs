using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Igraci")]
    public class Igrac
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
        [Range(1, 99)]
        public int BrojDresa { get; set; }

        [Required]
        [Range(16, 42)]
        public int BrojGodina { get; set; }

        [Required]
        [Range(1, 5)]
        public int Kvalitet { get; set; }

        [Required]
        public Pozicija Pozicija { get; set; }

        [Required]
        public Nacionalnost Nacionalnost { get; set; }

        public virtual TimFC Tim { get; set; }
    }
}