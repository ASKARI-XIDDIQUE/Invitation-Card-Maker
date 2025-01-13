using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Invitation_Card_Maker.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Invitation_Card_Maker.Services
{
    public class CustomTemplateService
    {
        private readonly ICustomTemplatesRepository customRepo;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ITemplateUserImagesRepository templateUserImageRepository;
        private readonly ITemplateTextBoxRepository templateTextBoxRepository;
        private readonly ITemplateStickerRepository templateStickerRepository;

        public CustomTemplateService(ICustomTemplatesRepository customTemplates, IWebHostEnvironment hostEnvironment, ITemplateTextBoxRepository templateTextBoxRepository, ITemplateUserImagesRepository templateUserImageRepository, ITemplateStickerRepository templateStickerRepository)
        {
            customRepo = customTemplates;
            _hostingEnvironment = hostEnvironment;
            this.templateUserImageRepository = templateUserImageRepository;
            this.templateTextBoxRepository = templateTextBoxRepository;
            this.templateStickerRepository = templateStickerRepository;
        }



     public async Task<CustomTemplateResponseDTO> CreateAsync(CustomTemplatesRequestDTO request)
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

                var customTemplate = new CustomTemplates
                {
                    UserId = request.UserId,
                    ImagePath = "/uploads/" + uniqueFileName,
                    Title = request.Title,
                    Description = request.Description,
                    Content = request.Content,
                    ContentStyles = request.ContentStyles,
                    DescriptionStyles = request.DescriptionStyles,
                    TitleStyles = request.TitleStyles,
                    Active = true,
                };

                var newCustomTemplate = await customRepo.Create(customTemplate);

                if (request.UserImageList != null && request.UserImageList.Count > 0)
                {
                    foreach (var stickerDTO in request.UserImageList)
                    {
                        if (stickerDTO.ImagePath != null && stickerDTO.ImagePath.Length > 0)
                        {
                            var stickerUniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(stickerDTO.ImagePath.FileName);
                            var stickerFilePath = Path.Combine(uploadsDir, stickerUniqueFileName);
                            using (var stickerFileStream = new FileStream(stickerFilePath, FileMode.Create))
                            {
                                await stickerDTO.ImagePath.CopyToAsync(stickerFileStream);
                            }

                            var sticker = new TemplateUserImages
                            {
                                ImagePath = "/uploads/" + stickerUniqueFileName,
                                ImageStyles = stickerDTO.ImageStyle,
                                CustomTemplateId = newCustomTemplate.GlobalId
                            };

                            await templateUserImageRepository.Create(sticker);
                        }
                    }
                }

                if (request.TextBoxList != null && request.TextBoxList.Count > 0)
                {
                    foreach (var textBoxDTO in request.TextBoxList)
                    {
                        var textBox = new TemplateTextBox
                        {
                            TextBox = textBoxDTO.TextBox,
                            Style = textBoxDTO.TextBoxStyles,
                            CustomTemplateId = newCustomTemplate.GlobalId
                        };

                        await templateTextBoxRepository.Create(textBox);
                    }
                }

                if (request.StickerList != null && request.StickerList.Count > 0)
                {
                    foreach (var stickerDTO in request.StickerList)
                    {
                        var sticker = new TemplateStickers
                        {
                            StickerId = stickerDTO.StickerId,
                            CustomTemplateId = newCustomTemplate.GlobalId
                        };

                        await templateStickerRepository.Create(sticker);
                    }
                }

                return new CustomTemplateResponseDTO
                {
                    GlobalId = newCustomTemplate.GlobalId,
                    Active = newCustomTemplate.Active,
                    UserId = newCustomTemplate.UserId,
                    ImagePath = newCustomTemplate.ImagePath,
                    Title = newCustomTemplate.Title,
                    Description = newCustomTemplate.Description,
                    Content = newCustomTemplate.Content,
                    DescriptionStyles = newCustomTemplate.DescriptionStyles,
                    ContentStyles = newCustomTemplate.ContentStyles,
                    TitleStyles = newCustomTemplate.TitleStyles,
                    CreatedAt = newCustomTemplate.CreatedAt,
                    ListTextBoxes = newCustomTemplate.TemplateTextBox.Select(
                        textBox => new TextBoxResponseDTO
                        {
                            TextBox = textBox.TextBox,
                            StyleTextBox = textBox.Style
                        }).ToList(),
                    UserImageList = newCustomTemplate.TemplateUserImages.Select(
                        tp => new UserTemplateImagesResponseDTO
                        {
                            ImagePath = tp.ImagePath,
                            ImageStyle = tp.ImageStyles
                        }).ToList(),
                    StickerList = newCustomTemplate.StickerList.Select(
                        sticker => new StickerResponseDTO
                        {
                            GlobalId = sticker.Stickers.GlobalId,
                            Active = sticker.Stickers.Active,
                            Sticker = sticker.Stickers.Sticker,
                            StickerStyle = sticker.Stickers.StickerStyle
                        }).ToList()
                };
            }
            else
            {
                throw new Exception("Please select the file");
            }
        }        
        public async Task<TemplateResponseDTO> RemoveTemplateAsync(Guid templateId)
            {
                var template = await customRepo.GetTemplateId(templateId);

                if (template == null)
                {
                    throw new Exception("Template not Found");
                }

                template.Active = false;
                await customRepo.Update(template);

                return new TemplateResponseDTO
                {
                    GlobalId = template.GlobalId,
                    Active = template.Active,
                    ImagePath = template.ImagePath,
                };
            }

            public async Task<List<CustomTemplateResponseDTO>> GetCustomTemplatesAsync(Guid userId)
            {
                var templates = await customRepo.GetCustomTemplatesByUserId(userId);

                return templates.Select(template => new CustomTemplateResponseDTO
                {
                    GlobalId = template.GlobalId,
                    Active = template.Active,
                    UserId = template.UserId,
                    ImagePath = template.ImagePath,
                    Title = template.Title,
                    Description = template.Description,
                    Content = template.Content,
                    CreatedAt = template.CreatedAt,
                    UserImageList = template.TemplateUserImages.Select(
                      st => new UserTemplateImagesResponseDTO
                      {
                          ImagePath=st.ImagePath,
                          ImageStyle=st.ImageStyles
                      }

                      ).ToList(),
                    ListTextBoxes = template.TemplateTextBox.Select(
                     tb => new TextBoxResponseDTO
                     {
                         TextBox = tb.TextBox,
                         StyleTextBox = tb.Style,
                     }

                      ).ToList(),
                }).ToList();
            }
           public async Task<CustomTemplateResponseDTO> UpdateTemplateAsync(CustomTemplateUpdateRequestDTO request)
           {
            var template = await customRepo.GetTemplateId(request.CustomTemplateId);

            if (template == null)
            {
                throw new Exception("Template not found");
            }

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
            }

            template.Title = request.Title;
            template.Description = request.Description;
            template.Content = request.Content;
            template.ContentStyles = request.ContentStyles;
            template.DescriptionStyles = request.DescriptionStyles;
            template.TitleStyles = request.TitleStyles;
            template.UpdatedAt = DateTime.Now;

            await customRepo.Update(template);

            await templateUserImageRepository.DeleteByTemplateId(template.GlobalId);

            if (request.UserImageList != null && request.UserImageList.Count > 0)
            {
                foreach (var stickerDTO in request.UserImageList)
                {
                    if (stickerDTO.ImagePath != null && stickerDTO.ImagePath.Length > 0)
                    {
                        var uploadsDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                        var stickerUniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(stickerDTO.ImagePath.FileName);
                        var stickerFilePath = Path.Combine(uploadsDir, stickerUniqueFileName);
                        using (var stickerFileStream = new FileStream(stickerFilePath, FileMode.Create))
                        {
                            await stickerDTO.ImagePath.CopyToAsync(stickerFileStream);
                        }

                        var sticker = new TemplateUserImages
                        {
                            ImagePath = "/uploads/" + stickerUniqueFileName,
                            ImageStyles = stickerDTO.ImageStyle,
                            CustomTemplateId = template.GlobalId
                        };

                        await templateUserImageRepository.Create(sticker);
                    }
                }
            }

            if (request.TextBoxRequestDTO != null && request.TextBoxRequestDTO.Count > 0)
            {
                await templateTextBoxRepository.DeleteByTemplateId(template.GlobalId);

                foreach (var textBoxDTO in request.TextBoxRequestDTO)
                {
                    var textBox = new TemplateTextBox
                    {
                        TextBox = textBoxDTO.TextBox,
                        Style = textBoxDTO.TextBoxStyles,
                        CustomTemplateId = template.GlobalId
                    };

                    await  templateTextBoxRepository.Create(textBox);
                }
            }

            return new CustomTemplateResponseDTO
            {
                GlobalId = template.GlobalId,
                Active = template.Active,
                UserId = template.UserId,
                ImagePath = template.ImagePath,
                Title = template.Title,
                Description = template.Description,
                Content = template.Content,
                CreatedAt = template.CreatedAt,
                ListTextBoxes = template.TemplateTextBox.Select(
                            textBox => new TextBoxResponseDTO
                            {
                                TextBox = textBox.TextBox,
                                StyleTextBox = textBox.Style

                            }

                            ).ToList(),
                UserImageList = template.TemplateUserImages.Select(
                            sticker => new UserTemplateImagesResponseDTO
                            {
                                ImagePath = sticker.ImagePath,
                                ImageStyle = sticker.ImageStyles,
                            }


                          ).ToList()

            };
        }

        public async Task<List<CustomTemplateResponseDTO>> GetUserTemplates(Guid userId)
        {
            List<CustomTemplates> userTemplates = await customRepo.GetCustomTemplatesByUserId(userId);
            List<CustomTemplateResponseDTO> customTemplateResponseDTOs = userTemplates.Select(
                ct => new CustomTemplateResponseDTO
                {
                    ImagePath = ct.ImagePath,
                    Title = ct.Title,
                    Description = ct.Description,
                    Content = ct.Content,
                    CreatedAt = ct.CreatedAt,
                    ContentStyles = ct.ContentStyles,
                    DescriptionStyles = ct.DescriptionStyles,
                    Active = ct.Active,
                    TitleStyles = ct.TitleStyles,
                    GlobalId = ct.GlobalId,
                    UserImageList = ct.TemplateUserImages.Select(
                        st => new UserTemplateImagesResponseDTO
                        {
                            ImagePath = st.ImagePath,
                            ImageStyle = st.ImageStyles,
                        }
                    ).ToList(),
                    ListTextBoxes = ct.TemplateTextBox.Select(
                        tb => new TextBoxResponseDTO
                        {
                            TextBox = tb.TextBox,
                            StyleTextBox = tb.Style,
                        }
                    ).ToList(),
                    StickerList = ct.StickerList.Select(
                        ts => new StickerResponseDTO
                        {
                            GlobalId = ts.Stickers.GlobalId,
                            Active = ts.Stickers.Active,
                            Sticker = ts.Stickers.Sticker,
                            StickerStyle = ts.Stickers.StickerStyle
                        }
                    ).ToList()
                }
            ).ToList();
            return customTemplateResponseDTOs;
        }
    }

}



    

