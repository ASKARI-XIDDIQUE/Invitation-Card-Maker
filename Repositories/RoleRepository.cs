using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class RoleRepository:BaseRepository<Role>,IRoleRepository
    {
        private readonly InvitationDbContext _context;
        public RoleRepository(InvitationDbContext context):base(context) 
        {
            _context=context;
        }

        public async Task<Role> GetById(Guid id)
        {
            return await _context.Role
                .FirstOrDefaultAsync(r => r.GlobalId == id);
        }

        public async Task<Role> GetByName()
        {
            return await _context.Role
                .FirstOrDefaultAsync(r => r.RoleName == "User");
        }
    }
}
