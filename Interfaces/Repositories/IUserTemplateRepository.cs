using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface IUserTemplateRepository:IBaseRepository<UserTemplate>
    {
        Task<UserTemplate> GetByIdAsync(Guid id);
        Task<List<UserTemplate>> GetByUserIdAsync(Guid id);
        Task<List<Template>> GetTemplatesByUserId(Guid UserId);

    }
}
