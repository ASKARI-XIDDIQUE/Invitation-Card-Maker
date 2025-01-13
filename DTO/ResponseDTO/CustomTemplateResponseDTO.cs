using Invitation_Card_Maker.DTO.RequestDTO;

namespace Invitation_Card_Maker.DTO.ResponseDTO
{
    public class CustomTemplateResponseDTO
    {
        public Guid GlobalId { get; set; }
        public Guid UserId { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string? TitleStyles { get; set; }
        public string? ContentStyles { get; set; }
        public string? DescriptionStyles { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public List<TextBoxResponseDTO>? ListTextBoxes { get; set; }
        public ICollection<UserTemplateImagesResponseDTO>? UserImageList { get; set; }
        public ICollection<StickerResponseDTO>? StickerList { get; set; }   

    }
}
