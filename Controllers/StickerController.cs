using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invitation_Card_Maker.Controllers
{
    public class StickerController : BaseController
    {
        private readonly StickerService _stickerService;

        public StickerController(StickerService stickerService)
        {
            _stickerService = stickerService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> CreateAsync([FromForm] StickerRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { ValidationError = ModelState });
            }

            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _stickerService.CreateStickerAsync(request),
                    message = "Sticker created successfully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<JsonResult> UpdateAsync([FromRoute] Guid id, [FromBody] StickerRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { ValidationError = ModelState });
            }

            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _stickerService.UpdateStickerAsync(id, request),
                    message = "Sticker updated successfully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteAsync([FromForm] Guid id)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _stickerService.RemoveStickerAsync(id),
                    message = "Sticker Deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<JsonResult> GetAllAsync()
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _stickerService.GetAllAsync(),
                    message = "Stickers listed successfully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
    }
}
