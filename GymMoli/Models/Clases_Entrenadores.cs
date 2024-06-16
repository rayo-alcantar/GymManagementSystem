using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMoli.Models
{
    public class Clases_Entrenadores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Clase_Entrenador { get; set; }

        [Required]
        public int ID_Clase { get; set; }

        [ForeignKey("ID_Clase")]
        public Clases? Clase { get; set; } // Hacer opcional

        [Required]
        public int ID_Entrenador { get; set; }

        [ForeignKey("ID_Entrenador")]
        public Entrenadores? Entrenador { get; set; } // Hacer opcional
    }
}
