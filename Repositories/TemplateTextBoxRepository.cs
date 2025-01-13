using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class TemplateTextBoxRepository : BaseRepository<TemplateTextBox>, ITemplateTextBoxRepository
    {
        private readonly InvitationDbContext _context;
        public TemplateTextBoxRepository(InvitationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task DeleteByTemplateId(Guid templateId)
        {
            var stickers = await _context.TemplateTextBox
                .Where(ts => ts.CustomTemplateId == templateId)
                .ToListAsync();

            _context.TemplateTextBox.RemoveRange(stickers);
            await _context.SaveChangesAsync();
                
        }
    }
}
