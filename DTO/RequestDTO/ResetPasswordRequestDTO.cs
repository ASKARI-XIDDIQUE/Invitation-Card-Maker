namespace Invitation_Card_Maker.DTO.RequestDTO
{
    public class ResetPasswordRequestDTO
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }

    }
}
