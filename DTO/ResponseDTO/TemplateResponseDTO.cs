namespace Invitation_Card_Maker.DTO.ResponseDTO
{
    public class TemplateResponseDTO
    {
        public Guid GlobalId { get; set; }
        public bool Active { get;set; }
        public Guid CategoryId { get; set; }
        public string ImagePath { get; set; }
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
        public DateTime CreatedAt { get; set; }
        //public string? TopTitle { get; set; }
        //public string? TopContent { get; set; }
        //public string? TopDescription { get; set; }
        public string? TitleStyles { get; set; }
        public string? ContentStyles { get; set; }
        public string? DescriptionStyles { get; set; }

    }
}
