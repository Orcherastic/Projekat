using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Nacionalnosti")]
    public class Nacionalnost
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Drzavljanstvo { get; set; }
    }
}