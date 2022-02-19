using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Timovi")]
    public class TimFC
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        [Range(1, 5)]
        public int Kvalitet { get; set; }
        
        public List<Igrac> Igraci { get; set; }
    }
}