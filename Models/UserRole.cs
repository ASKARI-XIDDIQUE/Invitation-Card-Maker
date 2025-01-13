using System.ComponentModel.DataAnnotations.Schema;

namespace Invitation_Card_Maker.Models
{
    public class UserRole:BaseClass
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
