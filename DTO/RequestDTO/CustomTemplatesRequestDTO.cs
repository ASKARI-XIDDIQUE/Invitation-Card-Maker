using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.DTO.RequestDTO
{
    public class CustomTemplatesRequestDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string? TitleStyles { get; set; }
        public string? ContentStyles { get; set; }
        public string? DescriptionStyles { get; set; }
        public ICollection<TextBoxRequestDTO>? TextBoxList { get; set; }
        public ICollection<UserTemplateImagesRequestDTO>? UserImageList { get; set; }
        public ICollection<StickerTemplateCreateRequestDTO>? StickerList { get; set; }


    }
}
