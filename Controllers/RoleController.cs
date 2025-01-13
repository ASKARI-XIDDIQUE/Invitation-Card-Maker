using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invitation_Card_Maker.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : BaseController
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] RoleRequestDTO request)
        {
            try
            {
                return new JsonResult
                    (
                    new
                    {
                        success = true,
                        data = await _roleService.CreateAsync(request),
                        message = "Created SuccessFully"
                    }
                    );
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            try
            {
                return new JsonResult
                (
                    new
                    {
                        success = true,
                        data = await _roleService.GetAllAsync(),
                        message = "Listed SuccessFully"
                    }
                    );
                ;
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        [HttpPut]
        public async Task<JsonResult> Put([FromBody] RoleRequestDTO request)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _roleService.UpdateAsync(request),
                    Message = "Update SuccessFully"

                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _roleService.DeleteAsync(id),
                    Message = "Deleted SuccessFully"
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
    }
}
