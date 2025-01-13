using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invitation_Card_Maker.Services
{
    public class TemplateService
    {
        private readonly ITemplateRepository _tempRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public TemplateService(ITemplateRepository tempRepository, IWebHostEnvironment hostingEnvironment)
        {
            _tempRepository = tempRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<TemplateResponseDTO> CreateTemplateAsync(TemplateCreateRequestDTO request)
        {
            if (request.ImageFile != null && request.ImageFile.Length > 0)
            {
                var uploadsDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsDir))
                {
                    Directory.CreateDirectory(uploadsDir);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(request.ImageFile.FileName);
                var filePath = Path.Combine(uploadsDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ImageFile.CopyToAsync(fileStream);
                }

                var template = new Template
                {
                    CategoryId = request.CategoryId,
                    ImagePath = "/uploads/" + uniqueFileName,
                    Title=request.Title,
                   
                    Description=request.Description,
                    Content=request.Content,
                    TitleStyles=request.TitleStyles,
                    ContentStyles=request.ContentStyles,
                    DescriptionStyles=request.DescriptionStyles,
                    
                    Active=true,
                    CreatedAt=System.DateTime.Now,

                };

                await _tempRepository.Create(template);

                var templateResponseDTO = new TemplateResponseDTO
                {
                    GlobalId = template.GlobalId, 
                    Active = template.Active,   
                    CategoryId = template.CategoryId,
                    ImagePath = template.ImagePath,
                    Title = template.Title,
                    Description = template.Description,
                    Content = template.Content,
                   
                    ContentStyles = template.ContentStyles,
                    DescriptionStyles = template.DescriptionStyles,
                    TitleStyles = template.TitleStyles,
                    CreatedAt=template.CreatedAt,
                };

                return templateResponseDTO;
            }

            throw new ArgumentException("ImageFile is required.");
        }
        public async Task<TemplateResponseDTO> RemoveTemplateAsync(Guid templateId)
        {
            var template = await _tempRepository.GetTemplateById(templateId);

            if (template == null)
            {
                throw new Exception("Template not Found"); 
            }

            template.Active = false;

            await _tempRepository.Update(template);

            return new TemplateResponseDTO
            {
                GlobalId = template.GlobalId,
                Active = template.Active,
                CategoryId = template.CategoryId,
                ImagePath = template.ImagePath,
               
                ContentStyles = template.ContentStyles,
                DescriptionStyles = template.DescriptionStyles,
                TitleStyles = template.TitleStyles,

            };
        }
        public async Task<TemplateResponseDTO> UpdateTemplateAsync( TemplateRequestDTO request)
        {
            var template = await _tempRepository.GetTemplateById(request.globalId);

            if (template == null)
            {
                throw new Exception("Template not found");
            }

            template.CategoryId = request.CategoryId;
            if (request.ImageFile != null && request.ImageFile.Length > 0)
            {
                var uploadsDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsDir))
                {
                    Directory.CreateDirectory(uploadsDir);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(request.ImageFile.FileName);
                var filePath = Path.Combine(uploadsDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ImageFile.CopyToAsync(fileStream);
                }

                template.ImagePath = "/uploads/" + uniqueFileName;
                template.CategoryId= request.CategoryId;
                template.Content = request.Content;
                template.Description=request.Description;
                template.Description = request.Description;
                template.Content = request.Content;
                template.Title = request.Title;
                template.ContentStyles = request.ContentStyles;
                template.TitleStyles = request.TitleStyles;
                template.DescriptionStyles = request.DescriptionStyles;
                template.UpdatedAt = System.DateTime.Now;

            }

            await _tempRepository.Update(template);

            return new TemplateResponseDTO
            {
                GlobalId = template.GlobalId,
                Active = template.Active,
                CategoryId = template.CategoryId,
                ImagePath = template.ImagePath,
                Description= template.Description,
                Title= template.Title,
                Content=template.Content,
            };
        }
        public async Task<List<TemplateResponseDTO>> GetAllAsync()
        {
            List<Template> templates = await _tempRepository.Get();

            List<TemplateResponseDTO> templateResponseDTOs = templates
                .Where(tp => tp.Active)
                .Select(tp => new TemplateResponseDTO
                {
                    GlobalId = tp.GlobalId,
                    Active = tp.Active,
                    CategoryId = tp.CategoryId,
                    ImagePath = tp.ImagePath,
                    Title = tp.Title,
                    Content = tp.Content,
                    Description = tp.Description,
                   
                    TitleStyles = tp.TitleStyles,
                    ContentStyles = tp.ContentStyles,
                    DescriptionStyles = tp.DescriptionStyles,

                })
                .ToList();

            return templateResponseDTOs;
        }
    }
}

    


