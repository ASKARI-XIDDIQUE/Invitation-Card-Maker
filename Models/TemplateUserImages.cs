using System.ComponentModel.DataAnnotations.Schema;

namespace Invitation_Card_Maker.Models
{
    public class TemplateUserImages:BaseClass
    {
        public string ImagePath { get; set; }
        public string ImageStyles {  get; set; }
        [ForeignKey("CustomTemplates")]
        public Guid CustomTemplateId { get; set; }
        public CustomTemplates CustomTemplates { get; set; }
    }
}
