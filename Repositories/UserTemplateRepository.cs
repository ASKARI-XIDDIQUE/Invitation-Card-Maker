using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invitation_Card_Maker.Repositories
{
    public class UserTemplateRepository : BaseRepository<UserTemplate>, IUserTemplateRepository
    {
        private readonly InvitationDbContext _context;

        public UserTemplateRepository(InvitationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserTemplate> GetByIdAsync(Guid id)
        {
            return await _context.UserTemplate
                .FirstOrDefaultAsync(ut => ut.GlobalId==id);
        }

        public async Task<List<UserTemplate>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserTemplate
                .Where(ut => ut.GlobalId == userId)
                .ToListAsync();
        }
        public async Task<List<Template>> GetTemplatesByUserId(Guid userId)
        {
            var userTemplates = await _context.UserTemplate
                .Where(ut => ut.UserId == userId)
                .Include(ut => ut.Template)  
                .ToListAsync();

            return userTemplates.Select(ut => ut.Template).ToList();
        }

      
    }
}
