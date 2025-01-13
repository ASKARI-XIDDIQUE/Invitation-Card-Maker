using Invitation_Card_Maker.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface IUserRoleRepository:IBaseRepository<UserRole>
    {
        Task<List<string>> GetUserRolesAsync(Guid userId);
    }
}
