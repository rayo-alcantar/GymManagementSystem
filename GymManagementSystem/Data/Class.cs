using System;
using System.Collections.Generic;

namespace GymManagementSystem.Models
{
    /// <summary>
    /// Representa una clase en el gimnasio.
    /// </summary>
    public class Class
    {
        /// <summary>
        /// Obtiene o establece el ID de la clase.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la clase.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción de la clase.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Obtiene o establece el horario de la clase.
        /// </summary>
        public DateTime Schedule { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del instructor de la clase.
        /// </summary>
        public int InstructorId { get; set; }

        /// <summary>
        /// Obtiene o establece el instructor de la clase.
        /// </summary>
        public Instructor Instructor { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de miembros inscritos en la clase.
        /// </summary>
        public ICollection<ClassMember> ClassMembers { get; set; }
    }
}
