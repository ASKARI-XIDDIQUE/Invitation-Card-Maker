using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface ICustomTemplatesRepository:IBaseRepository<CustomTemplates>
    {
        Task<List<CustomTemplates>> GetCustomTemplatesByUserId(Guid userId);
        Task<CustomTemplates> GetTemplateId(Guid customTemplateId);
        Task<List<CustomTemplates>> GetTemplatesByUserId(Guid userId);
    }
}
