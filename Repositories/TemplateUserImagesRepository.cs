using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class TemplateUserImagesRepository : BaseRepository<TemplateUserImages>, ITemplateUserImagesRepository
    {
        private readonly InvitationDbContext _context;
        public TemplateUserImagesRepository(InvitationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task DeleteByTemplateId(Guid templateId)
        {
            var stickers = await _context.TemplateUserImages
                .Where(ts => ts.CustomTemplateId == templateId)
                .ToListAsync();

            _context.TemplateUserImages.RemoveRange(stickers);
            await _context.SaveChangesAsync();
        }
    }
}
