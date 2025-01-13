using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.Eventing.Reader;

namespace Invitation_Card_Maker.Services
{
    public class StickerService
    {
        private readonly IStickerRepository _stickerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public StickerService(IStickerRepository stickerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _stickerRepository = stickerRepository;
            _hostingEnvironment = webHostEnvironment;
        }

        public async Task<StickerResponseDTO> CreateStickerAsync(StickerRequestDTO request)
        {
           if(request.Sticker!=null && request.Sticker.Length > 0)
            {
                var uploadsDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsDir))
                {
                    Directory.CreateDirectory(uploadsDir);
                }
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(request.Sticker.FileName);
                var filePath = Path.Combine(uploadsDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Sticker.CopyToAsync(fileStream);
                }
                var sticker = new Stickers()
                {
                    Sticker = "/uploads/" + uniqueFileName,
                    StickerStyle=request.StickerStyle,
                    Active = true,
                    CreatedAt = System.DateTime.Now,
                };
                await _stickerRepository.Create(sticker);
                return new StickerResponseDTO
                { 
                    Sticker=sticker.Sticker,
                    StickerStyle=sticker.StickerStyle,
                    Active = true,                
                };
               

            }
            else
            {
                throw new Exception("Image file is required");
            }


        }

        public async Task<StickerResponseDTO> RemoveStickerAsync(Guid stickerId)
        {
            var sticker = await _stickerRepository.GetStickerById(stickerId);

            if (sticker == null)
            {
                throw new Exception("Sticker not found");
            }

            sticker.Active = false;
            sticker.DeletedAt = DateTime.Now;
            await _stickerRepository.Update(sticker);

            return new StickerResponseDTO
            {
                GlobalId = sticker.GlobalId,
                Active = sticker.Active,
                Sticker = sticker.Sticker,
                StickerStyle = sticker.StickerStyle
            };
        }

        public async Task<StickerResponseDTO> UpdateStickerAsync(Guid id, StickerRequestDTO request)
        {
            var sticker = await _stickerRepository.GetStickerById(id);

            if (sticker == null)
            {
                throw new Exception("Sticker not found");
            }
            if (request.Sticker != null && request.Sticker.Length > 0)
            {
                var uploadsDir = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsDir))
                {
                    Directory.CreateDirectory(uploadsDir);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(request.Sticker.FileName);
                var filePath = Path.Combine(uploadsDir, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Sticker.CopyToAsync(fileStream);
                }
                sticker.Sticker = "/uploads/" + uniqueFileName;
                sticker.StickerStyle = request.StickerStyle;
                sticker.UpdatedAt = DateTime.Now;

                
            }
            await _stickerRepository.Update(sticker);

            return new StickerResponseDTO
            {
                GlobalId = sticker.GlobalId,
                Active = sticker.Active,
                Sticker = sticker.Sticker,
                StickerStyle = sticker.StickerStyle
            };
        }

        public async Task<List<StickerResponseDTO>> GetAllAsync()
        {
            var stickers = await _stickerRepository.Get();

            return stickers
                .Where(sticker => sticker.Active)
                .Select(sticker => new StickerResponseDTO
                {
                    GlobalId = sticker.GlobalId,
                    Active = sticker.Active,
                    Sticker = sticker.Sticker,
                    StickerStyle = sticker.StickerStyle
                })
                .ToList();
        }
    }
}
