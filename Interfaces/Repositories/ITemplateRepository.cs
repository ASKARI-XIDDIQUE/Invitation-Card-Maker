using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Models;
using Invitation_Card_Maker.Repositories;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface ITemplateRepository:IBaseRepository<Template>
    {
        Task<List<TemplateResponseDTO>> GetByCategory(Guid categoryId);
        Task<Template> GetTemplateById(Guid id);

    }
}
