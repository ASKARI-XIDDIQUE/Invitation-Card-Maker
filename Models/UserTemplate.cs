using System.ComponentModel.DataAnnotations.Schema;

namespace Invitation_Card_Maker.Models
{
    public class UserTemplate:BaseClass
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Template")]
        public Guid TemplateId { get; set; }
        public Template Template { get; set; }
    }
}
