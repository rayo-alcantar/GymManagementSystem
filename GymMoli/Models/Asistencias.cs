using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMoli.Models
{
    public class Asistencias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Asistencia { get; set; }

        [Required]
        public int ID_Clase { get; set; }

        [ForeignKey("ID_Clase")]
        public Clases? Clase { get; set; } // Hacer opcional

        [Required]
        public int ID_Cliente { get; set; }

        [ForeignKey("ID_Cliente")]
        public Clientes? Cliente { get; set; } // Hacer opcional

        [Required]
        public DateTime Fecha_Asistencia { get; set; }

        // Constructor sin parámetros
        public Asistencias()
        {
            Clase = null;
            Cliente = null;
        }
    }
}
