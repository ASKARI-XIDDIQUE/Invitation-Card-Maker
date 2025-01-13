using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class UserRoleRepository :BaseRepository<UserRole>, IUserRoleRepository
    {
        private readonly InvitationDbContext _context;

        public UserRoleRepository(InvitationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUserRolesAsync(Guid userId)
        {
            return await _context.UserRole
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role.RoleName)
                .ToListAsync();
        }
    }
}
