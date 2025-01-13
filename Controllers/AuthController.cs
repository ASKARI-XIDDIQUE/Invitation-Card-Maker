using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Invitation_Card_Maker.Controllers
{
    
    public class AuthController : BaseController
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var authResponse = await _authService.LoginAsync(request);
                return new JsonResult(new
                {
                    success = true,
                    token = authResponse.JwtToken,
                    refreshToken = authResponse.RefreshToken,
                    Email=authResponse.Email,
                    UserName=authResponse.UserName,
                    message = "Login Successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("Register")]
        public async Task<IActionResult>  Register([FromBody] RegisterRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                return new JsonResult(new { 
                success=true,
                data=await _authService.CreateUserAsync(request),
                Message="User Account created SuccessFully"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new {Messsage=ex.Message });
            }
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var authResponse = await _authService.RefreshTokenAsync(request);
                return new JsonResult(new
                {
                    success = true,
                    token = authResponse.JwtToken,
                    refreshToken = authResponse.RefreshToken
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authService.ForgotPasswordAsync(request);
                return new JsonResult(new { success = true, message = "OTP sent to email successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                
                return new JsonResult(new { success = true,
                    data= await _authService.VerifyOtpAsync(request), 
                    message = "OTP Verify successfully" 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("ConfirmPassword")]
        public async Task<IActionResult> ConfirmPassword([FromBody] ConfirmPasswordRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                      return new JsonResult
                    (
                          new 
                    { 
                        success = true, 
                        message =await _authService.ConfirmPassword(request),

            });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDTO request)
        {
            try
            {
                return new JsonResult
                    (
                    new
                    {
                        success = true,
                        data = await _authService.ResetPasswordAsync(request),
                        Message = "Password Reset SuccessFully",
                    });
            }

            catch (Exception ex)
            {
                return new JsonResult (new { error=ex.Message });   
            }
        }


    }
}
