namespace Invitation_Card_Maker.DTO.ResponseDTO
{
    public class UserTemplateResponseDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<TemplateResponseDTO> TemplateResponseList { get; set; }
    }
}
