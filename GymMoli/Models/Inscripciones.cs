using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GymMoli.Models
{
    public class Inscripciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Inscripción { get; set; }

        [Required]
        public int ID_Cliente { get; set; }

        [ForeignKey("ID_Cliente")]
        public required Clientes Cliente { get; set; }

        [Required]
        public int ID_Membresía { get; set; }

        [ForeignKey("ID_Membresía")]
        public required Membresias Membresía { get; set; }

        [Required]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        public DateTime Fecha_Fin { get; set; }

        [Required]
        [StringLength(20)]
        public required string Estado { get; set; }
    }
}
