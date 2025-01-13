using System.ComponentModel.DataAnnotations.Schema;

namespace Invitation_Card_Maker.Models
{
    public class TemplateTextBox:BaseClass
    {
        public string TextBox { get; set; }
        public string Style { get; set; }
        [ForeignKey("CustomTemplates")]
        public Guid CustomTemplateId { get; set; }
        public CustomTemplates CustomTemplates { get; set; }
    }
}
