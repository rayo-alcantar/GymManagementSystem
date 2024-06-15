using System.Collections.Generic;

namespace GymManagementSystem.Models
{
    /// <summary>
    /// Representa un instructor en el gimnasio.
    /// </summary>
    public class Instructor
    {
        /// <summary>
        /// Obtiene o establece el ID del instructor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del instructor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la especialidad del instructor.
        /// </summary>
        public string Specialty { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de clases impartidas por el instructor.
        /// </summary>
        public ICollection<Class> Classes { get; set; }
    }
}
