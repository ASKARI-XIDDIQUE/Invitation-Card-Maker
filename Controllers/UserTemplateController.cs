using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invitation_Card_Maker.Controllers
{
    public class UserTemplateController : Controller
    {
        private readonly UserTemplateService userTemplateService;
        public UserTemplateController(UserTemplateService userTemplateService)
        {
            this.userTemplateService = userTemplateService; 
        }
        [Authorize("Admin,User")]
        [HttpGet("{id}")]
        public async Task<JsonResult> GetUserTemplates(Guid id)
        {
            try
            {
                return new JsonResult(new    
               { 
                success=true,
                data=await userTemplateService.GetUserTemplatesByUserIdAsync(id),
                Message="User Templates Listed SuccessFuly"
                }
                );
            }
            catch(Exception ex)
            {
                return new JsonResult(new { error=ex.Message });
            }
            
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("User/Templates")]
        public async Task<JsonResult> SaveUserTemplates(UserTemplateRequestDTO request)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await userTemplateService.CreateUserTemplateAsync(request),
                    Message = "User Templates Save SuccessFuly"
                }
                );
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }

        }
    }
}
