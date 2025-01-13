namespace Invitation_Card_Maker.DTO.ResponseDTO
{
    public class AuthResponseDTO
    {
       
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
