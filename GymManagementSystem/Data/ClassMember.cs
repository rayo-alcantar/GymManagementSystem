using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystem.Models
{
    public class ClassMember
    {
        [Key]
        public int ClassMemberId { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
