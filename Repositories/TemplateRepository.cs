using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        private readonly InvitationDbContext _context;
        public TemplateRepository(InvitationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<TemplateResponseDTO>> GetByCategory(Guid categoryId)
        {
            var categories = await _context.Category
                                           .Include(c => c.Template)
                                           .Where(c => c.GlobalId == categoryId)
                                           .ToListAsync();

            var templateResponseDTOs = categories.SelectMany(c => c.Template)
                                                 .Select(t => new TemplateResponseDTO
                                                 {
                                                     GlobalId = t.GlobalId,
                                                     Active = t.Active,
                                                     CategoryId = t.CategoryId,
                                                     ImagePath = t.ImagePath,
                                                     TitleStyles = t.TitleStyles,
                                                     ContentStyles = t.ContentStyles,
                                                     DescriptionStyles = t.DescriptionStyles,
                                                     Title=t.Title,
                                                     Description=t.Description,
                                                     Content=t.Content,
                                                     
                                                 })
                                                 .ToList();

            return templateResponseDTOs;
        }
        public async Task<Template> GetTemplateById(Guid id)
        {
            return await _context.Template.FirstOrDefaultAsync(tmp => tmp.GlobalId == id);
        }

       
    }
}
