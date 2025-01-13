using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Repositories
{
    public  class CategoryRepository:BaseRepository<Category>, ICategoryRepository
    {
        private readonly InvitationDbContext _context;
        public CategoryRepository(InvitationDbContext context) :base(context) 
        {
            _context=context;
        }
        public async Task<Category> GetById(Guid id)
        {
            return await _context.Category.Where(ct=>ct.GlobalId==id).FirstOrDefaultAsync();
        }
        public async Task<List<Template>> GetTemplatesByCategoryId(Guid categoryId)
        {
            return await _context.Category
                .Where(c => c.GlobalId == categoryId)
                .SelectMany(c => c.Template)
                .ToListAsync();
        }
        public async Task<List<Template>> GetRandomTemplatesByCategoryId(Guid categoryId, int count)
        {
            var templates = await _context.Category
                .Where(c => c.GlobalId == categoryId)
                .SelectMany(c => c.Template)
                .ToListAsync();

            return templates.Take(count).ToList();
        }
       



    }
}
