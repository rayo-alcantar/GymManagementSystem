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
        public required Clases Clase { get; set; }

        [Required]
        public required int ID_Entrenador { get; set; }

        [ForeignKey("ID_Entrenador")]
        public required Entrenadores Entrenador { get; set; }
        
    }
}
