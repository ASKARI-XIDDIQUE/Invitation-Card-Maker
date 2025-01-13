using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface IRoleRepository:IBaseRepository<Role>
    {
        Task<Role> GetById(Guid id);
        Task<Role> GetByName();

    }
}
