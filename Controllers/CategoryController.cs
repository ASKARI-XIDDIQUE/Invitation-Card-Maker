using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invitation_Card_Maker.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService= categoryService;
        }

       
        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]CategoryRequestDTO request)
        {
            try
            {
                return new JsonResult
                    (
                    new
                    {
                        success = true,
                        data =await _categoryService.CreateAsync(request),
                        message = "Created SuccessFully"
                    }
                    ); 
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
       // [Authorize]
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
                        data=await _categoryService.GetAllAsync(),
                        message="Listed SuccessFully"
                    }
                    );
                ;
            }
            catch(Exception ex)
            {
                return new JsonResult(new {error= ex.Message});
            }
        }
      
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<JsonResult> Put([FromBody]CategoryRequestDTO request)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data =await _categoryService.UpdateAsync(request),
                    Message="Update SuccessFully"

                });  
            }
            catch(Exception ex)
            {
                return new JsonResult(new {error= ex.Message});   
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            try
            {
                return new JsonResult(new
                {
                    success = true,
                    data = await _categoryService.DeleteAsync(id),
                    Message="Deleted SuccessFully"
                }) ;
            }
            catch(Exception ex)
            {
                return new JsonResult(new { error=ex.Message});
            }
        }
        //[Authorize(Roles = "Admin,User")]

        [HttpGet("templates/{categoryId}")]
        public async Task<IActionResult> GetTemplatesByCategory(Guid categoryId)
        {
            try
            {
                return new JsonResult(new 
                {
                success=true,
                data=await _categoryService.GetTemplatesByCategoryAsync(categoryId),
                Message="Templates by category Listed SucessFully"                
                }
                ) ;

            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message});
            }
        }
        [HttpGet("RandomTemplates")]
        public async Task<IActionResult> GetRandomTemplatesByCategory([FromQuery] int count)
        {
            try
            {
                var templates = await _categoryService.GetRandomTemplatesByCategoryAsync(count);
                return new JsonResult(new
                {
                    success = true,
                    data = templates,
                    message = "Random templates listed successfully"
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
