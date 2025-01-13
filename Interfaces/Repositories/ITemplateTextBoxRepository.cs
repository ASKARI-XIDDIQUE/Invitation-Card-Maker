using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Interfaces.Repositories
{
    public interface ITemplateTextBoxRepository : IBaseRepository<TemplateTextBox>
    {
        Task DeleteByTemplateId(Guid templateId);

    }
}
