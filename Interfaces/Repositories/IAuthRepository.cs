using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Models;
using Invitation_Card_Maker.Repositories;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface IAuthRepository:IBaseRepository<User>
    {
        Task<User> FindUserAsync(AuthRequestDTO request);
        Task<User> GetByIdAsync(Guid id);
        Task SaveRefreshTokenAsync(User user, string refreshToken);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
        Task SaveResetPasswordOtpAsync(User user, string otp);
        Task<User> GetUserByOtpAsync(string email, string otp);
        Task<User> FindByEmailAsync(string email);
        Task<User> UpdatePassword(string email, string password);  


    }
}
