using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<Category> GetById(Guid id);
        Task<List<Template>> GetTemplatesByCategoryId(Guid categoryId);
        Task<List<Template>> GetRandomTemplatesByCategoryId(Guid categoryId, int count);
    }
}
