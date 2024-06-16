using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GymMoli.Models
{
    public class Clases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Clase { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre_Clase { get; set; }
        [Required]
        public string? Descripción { get; set; }

        [Required]
        [StringLength(10)]
        public string? Día { get; set; }

        [Required]
        public TimeSpan Hora_Inicio { get; set; }

        [Required]
        public TimeSpan Hora_Fin { get; set; }

        [Required]
        public int Capacidad { get; set; }
        public ICollection<Asistencias>? Asistencias { get; set; }
        public ICollection<Clases_Entrenadores>? Clases_Entrenadores { get; set; }
    }
}
