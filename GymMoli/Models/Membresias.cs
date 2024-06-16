using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GymMoli.Models
{
    public class Membresias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Membresía { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo_Membresía { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Duración_Días { get; set; }
    }
}
