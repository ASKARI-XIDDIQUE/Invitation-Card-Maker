using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class TemplateStickerRepository:BaseRepository<TemplateStickers>,ITemplateStickerRepository
    {
        private readonly InvitationDbContext _context;
        public TemplateStickerRepository(InvitationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Stickers>> GetStickersFromTemplate(Guid templateId)
        {
            return await _context.TemplateStickers
                .Where(ts => ts.CustomTemplateId == templateId && ts.Stickers.Active)
                .Include(ts => ts.Stickers)
                .Select(ts => ts.Stickers)
                .ToListAsync();
        }
    }
}
