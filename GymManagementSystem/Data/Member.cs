using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    /// <summary>
    /// Representa un miembro del gimnasio.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Obtiene o establece el ID del miembro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del miembro.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del miembro.
        /// </summary>
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de la membresía del miembro.
        /// </summary>
        [Required(ErrorMessage = "La fecha de membresía es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime MembershipDate { get; set; }

        /// <summary>
        /// Obtiene o establece la colección de clases a las que está inscrito el miembro.
        /// </summary>
        public ICollection<ClassMember> ClassMembers { get; set; }
    }
}
