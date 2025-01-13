using System.ComponentModel.DataAnnotations.Schema;

namespace Invitation_Card_Maker.Models
{
    public class TemplateStickers:BaseClass
    {
        [ForeignKey("Stickers")]
        public Guid StickerId { get; set; }
        public Stickers Stickers { get; set; }
        [ForeignKey("CustomTemplates")]
        public Guid CustomTemplateId { get; set; }
        public CustomTemplates CustomTemplates { get; set; }    
    }
}
