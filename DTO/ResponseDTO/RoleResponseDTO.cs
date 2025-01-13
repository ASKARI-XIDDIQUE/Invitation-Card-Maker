namespace Invitation_Card_Maker.DTO.ResponseDTO
{
    public class RoleResponseDTO
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; } 

    }
}
