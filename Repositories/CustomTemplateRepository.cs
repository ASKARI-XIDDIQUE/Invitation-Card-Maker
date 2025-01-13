using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class CustomTemplateRepository:BaseRepository<CustomTemplates>,ICustomTemplatesRepository
    {
        private readonly InvitationDbContext _context;
        public CustomTemplateRepository(InvitationDbContext context):base(context)
        {
            _context=context;
        }
        public async Task<List<CustomTemplates>> GetCustomTemplatesByUserId(Guid userId)
        {
            return await _context.CustomTemplates
                                 .Include(us => us.User)
                                 .Include(tx=>tx.TemplateTextBox)
                                 .Include(st=>st.TemplateUserImages)
                                 .Where(cs => cs.UserId == userId && cs.Active)
                                 .ToListAsync();
        }

        public async Task<CustomTemplates> GetTemplateId(Guid customTemplateId)
        {
            return await _context
                      .CustomTemplates.
                      Include(st=>st.TemplateUserImages).
                      Include(tx=>tx.TemplateTextBox).
                     FirstOrDefaultAsync(ct=>ct.GlobalId==customTemplateId);
        }

        public Task<List<CustomTemplates>> GetTemplatesByUserId(Guid userId)
        {
           var customTemplates=_context.CustomTemplates
                .Include(st=>st.TemplateUserImages)
                .Include(tx=>tx.TemplateTextBox)
                .Where(ct=>ct.UserId == userId).
                ToListAsync();
            return customTemplates;
        }
    }
}
