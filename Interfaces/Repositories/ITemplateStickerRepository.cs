using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface ITemplateStickerRepository:IBaseRepository<TemplateStickers>
    {
        Task<List<Stickers>> GetStickersFromTemplate(Guid id);
    }
}
