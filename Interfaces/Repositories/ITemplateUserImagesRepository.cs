using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface ITemplateUserImagesRepository:IBaseRepository<TemplateUserImages>
    {
        Task DeleteByTemplateId(Guid templateId);

    }
}
