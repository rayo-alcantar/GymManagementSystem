using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GymMoli.Models
{
    public class Entrenadores
    {
    [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Entrenador { get; set; }

        [Required]
        [StringLength(20)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string? Apellido { get; set; }

        [StringLength(50)]
        public string? Especialidad { get; set; }

        public required string Teléfono { get; set; }

        [Required]
        [StringLength(100)]
        public required string Email { get; set; }
        public ICollection<Clases_Entrenadores>? Clases_Entrenadores { get; set; }
    }
}
