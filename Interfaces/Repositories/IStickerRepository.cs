using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface IStickerRepository : IBaseRepository<Stickers>
    {
        Task<Stickers> GetStickerById(Guid id);
    }
}
