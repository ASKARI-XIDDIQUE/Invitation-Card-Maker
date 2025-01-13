using System.Collections.Generic;
using System.Threading.Tasks;
using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class StickerRepository : BaseRepository<Stickers>, IStickerRepository
    {
        private readonly InvitationDbContext _context;

        public StickerRepository(InvitationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Stickers> GetStickerById(Guid id)
        {
            return await _context.Stickers.FirstOrDefaultAsync(st=>st.GlobalId==id);
        }
    }
}
