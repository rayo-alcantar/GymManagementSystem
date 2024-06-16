using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMoli.Models
{
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Cliente { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string Apellido { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public string Género { get; set; }

        public string Teléfono { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime Fecha_Registro { get; set; }
    }
}
