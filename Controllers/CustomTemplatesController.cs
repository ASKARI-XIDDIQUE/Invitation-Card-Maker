using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Invitation_Card_Maker.Controllers
{
    public class CustomTemplatesController : BaseController
    {
        private readonly CustomTemplateService customTemplateService;
        public CustomTemplatesController(CustomTemplateService customTemplateService)
        {
            this.customTemplateService = customTemplateService;
        }
       //get user custom temp[late
        [HttpGet("{id}")]
        public async Task<JsonResult> GetUserCustomTemplates(Guid id)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await customTemplateService.GetCustomTemplatesAsync(id),
                    Message = "User Templates Listed SuccessFuly"
                }
                );
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }

        }
        //[Authorize(Roles = "Admin,User")]
        [HttpPost("User/CustomTemplates")]
        public async Task<JsonResult> CreateCustomTemplate([FromBody]CustomTemplatesRequestDTO request)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await customTemplateService.CreateAsync(request),
                    Message = "User Custom Templates Save SuccessFuly"
                }
                );
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }

        }
        [Authorize(Roles = "Admin,User")]

        [HttpPut]
        public async Task<JsonResult> Update([FromForm] CustomTemplateUpdateRequestDTO request)
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
                    data = await customTemplateService.UpdateTemplateAsync(request),
                    Message = "Updated SuccessFully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });

            }
        }
        [Authorize(Roles = "Admin,User")]

        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete([FromBody] Guid requestId)
        {
            try
            {
                return new JsonResult(
                    new
                    {
                        success = true,
                        data = await customTemplateService.RemoveTemplateAsync(requestId),
                        Message = "Updated SuccessFully"
                    });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });

            }
        }
        
    }
}
