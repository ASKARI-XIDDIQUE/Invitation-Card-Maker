using System.ComponentModel.DataAnnotations;

namespace Invitation_Card_Maker.DTO.RequestDTO
{
    public class TemplateCreateRequestDTO
    {
        public Guid CategoryId { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
        public string Title { get; set; }
        //public string? LefPosTitle { get; set; }
        //public string? RigPosTitle { get; set; }
        //public string? BottPosTitle { get; set; }
        public string Description { get; set; }
        //public string? LefPosDescription { get; set; }
        //public string? RigPosDescription { get; set; }
        //public string? BottPosDescription { get; set; }
        public string Content { get; set; }
        //public string? LeftPosContent { get; set; }
        //public string? RigPosContent { get; set; }
        //public string? BottPosContent { get; set; }
        //public string? TopTitle { get; set; }
        //public string? TopContent { get; set; }
        //public string? TopDescription { get; set; }
        public string? TitleStyles { get; set; }
        public string? ContentStyles { get; set; }
        public string? DescriptionStyles { get; set; }


    }
}
