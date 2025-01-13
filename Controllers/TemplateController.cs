using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invitation_Card_Maker.Controllers
{
    public class TemplateController : BaseController
    {
        private readonly TemplateService _templateService;
        public TemplateController(TemplateService templateService)
        {
            _templateService = templateService;
        }
        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<JsonResult> CreateAsync([FromForm]TemplateCreateRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { ValidationError = ModelState });
            }
            try
            {
                return new JsonResult(new 
                    { 
                    success= true,
                    data=await _templateService.CreateTemplateAsync(request),
                    Message="Template Created SuccessFully"
                    });
            }
            catch (Exception ex) { 
                return new JsonResult(new {error=ex.Message});
            
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<JsonResult> Update([FromBody]TemplateRequestDTO request)
        {
            if(!ModelState.IsValid)
            {
                return new JsonResult(new {ValidationError=ModelState });
            }
            try
            {
                return new JsonResult(new
                {
                    success=true,
                    data=await _templateService.UpdateTemplateAsync(request),
                    Message="Updated SuccessFully"
                });
            }
            catch(Exception ex)
            {
                return new JsonResult(new { error = ex.Message });

            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete([FromBody]Guid requestId)
          {
            try
            {
                return new JsonResult(
                    new
                    {
                        success = true,
                        data = await _templateService.RemoveTemplateAsync(requestId),
                        Message = "Updated SuccessFully"
                    });
            }
            catch(Exception ex)
            {
                return new JsonResult(new { error = ex.Message });

            }
        }
        //[Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                return new JsonResult(
                    new
                    {
                        success = true,
                        data = await _templateService.GetAllAsync(),
                        Message = "Listed SuccessFully"
                    }) ;
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });

            }
        }


    }
}
