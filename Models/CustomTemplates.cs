using Invitation_Card_Maker.DTO.RequestDTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invitation_Card_Maker.Models
{
    public class CustomTemplates:BaseClass
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string? TitleStyles { get; set; }
        public string? ContentStyles { get; set; }
        public string? DescriptionStyles { get; set; }
        public ICollection<TemplateTextBox>? TemplateTextBox { get; set; }
        public ICollection<TemplateUserImages>? TemplateUserImages { get; set; }
        public ICollection<TemplateStickers>? StickerList { get; set; }



    }
}
