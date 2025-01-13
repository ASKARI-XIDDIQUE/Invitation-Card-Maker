namespace Invitation_Card_Maker.DTO.RequestDTO
{
    public class UserTemplateImagesRequestDTO
    {
        public IFormFile? ImagePath {  get; set; }
        public string? ImageStyle { get; set; }
    }
}
