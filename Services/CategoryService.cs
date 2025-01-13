using AutoMapper;
using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO request)
        {

            //Category category=mapper.Map<Category>(request);
            //category.Active = true; 
            //category.CreatedAt = DateTime.Now;          
            
            Category category = new Category()
            {
                Name = request.CategoryName,
                CreatedAt = DateTime.UtcNow,
                Active = true,
            };
            Category newCategory = await _categoryRepository.Create(category);
            CategoryResponseDTO categoryResponse = new CategoryResponseDTO()
            {
                GlobalId = newCategory.GlobalId,
                Active = newCategory.Active,
                CategoryName = newCategory.Name,
            };
            return categoryResponse;
        }
        public async Task<List<CategoryResponseDTO>> GetAllAsync()
        {
            List<Category> categories = await _categoryRepository.Get();

            List<CategoryResponseDTO> categoryResponseDTOs = categories
                .Where(cat => cat.Active)
                .Select(cat => new CategoryResponseDTO
                {
                    GlobalId = cat.GlobalId,
                    CategoryName = cat.Name,
                    Active = cat.Active,
                })
                .ToList();

            return categoryResponseDTOs;
        }
        public async Task<CategoryResponseDTO> UpdateAsync(CategoryRequestDTO request)
        {
            Category existingCategory = await _categoryRepository.GetById(request.GlobalId);
            if (existingCategory == null)
            {
                throw new Exception("Category not Found");
            }
            else
            {
                existingCategory.Name = request.CategoryName;
                existingCategory.UpdatedAt = System.DateTime.Now;
                Category updatedCategory = await _categoryRepository.Update(existingCategory);
                CategoryResponseDTO categoryResponseDTO = new CategoryResponseDTO()
                {
                    GlobalId = existingCategory.GlobalId,
                    CategoryName = existingCategory.Name,
                    Active = existingCategory.Active,
                };
                return categoryResponseDTO;


            }
        }
        public async Task<bool> DeleteAsync(Guid request)
        {
            Category existingCategory = await _categoryRepository.GetById(request);
            if (existingCategory == null)
            {
                throw new Exception("Category not Found");
            }
            else
            {
                existingCategory.Active = false;
                existingCategory.DeletedAt = System.DateTime.Now;
                await _categoryRepository.Update(existingCategory);
                return true;

            }
        }
        public async Task<List<TemplateResponseDTO>> GetTemplatesByCategoryAsync(Guid categoryId)
        {
            List<Template> templates = await _categoryRepository.GetTemplatesByCategoryId(categoryId);

            List<TemplateResponseDTO> templateResponseDTOs = templates.Select(t => new TemplateResponseDTO
            {
                GlobalId = t.GlobalId,
                Active = t.Active,
                ImagePath = t.ImagePath,
                Title = t.Title,
                Description = t.Description,
                Content = t.Content,
                ContentStyles = t.ContentStyles,
                DescriptionStyles = t.DescriptionStyles,
                TitleStyles = t.TitleStyles,
            }).ToList();

            return templateResponseDTOs;
        }
            public async Task<List<TemplateResponseDTO>> GetRandomTemplatesByCategoryAsync(int count)
            {
            var categories = await _categoryRepository.Get();

            var randomTemplates = new List<TemplateResponseDTO>();

            foreach (var category in categories)
            {
                var templates = await _categoryRepository.GetRandomTemplatesByCategoryId(category.GlobalId, count);

                randomTemplates.AddRange(templates.Select(t => new TemplateResponseDTO
                {
                    GlobalId = t.GlobalId,
                    Active = t.Active,
                    CategoryId = t.CategoryId,
                    ImagePath = t.ImagePath,
                    Title = t.Title,
                    Description = t.Description,
                    Content = t.Content,
                    ContentStyles = t.ContentStyles,
                    DescriptionStyles = t.DescriptionStyles,
                    TitleStyles = t.TitleStyles,
                }).ToList());
            }

            return randomTemplates;
            }

    }
}