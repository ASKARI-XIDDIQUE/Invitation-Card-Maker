using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Invitation_Card_Maker.Services
{
    public class AuthService 
    {
        private readonly IConfiguration config;
        private readonly IAuthRepository authRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IRoleRepository roleRepository;
        public AuthService(IAuthRepository authRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IConfiguration config)
        {
            this.authRepository = authRepository;
            this.userRoleRepository = userRoleRepository;
            this.config = config;
            this.roleRepository = roleRepository;
        }
        public async Task<AuthResponseDTO> LoginAsync(AuthRequestDTO request)
        {
            var user = await authRepository.FindUserAsync(request);
            if (user != null)
            {
                var roles = await userRoleRepository.GetUserRolesAsync(user.GlobalId);

                var token = await GenerateToken(user, roles);
                var refreshToken = GenerateRefreshToken();
                await authRepository.SaveRefreshTokenAsync(user, refreshToken);

                return new AuthResponseDTO
                {
                    JwtToken = token,
                    RefreshToken = refreshToken,
                    Email = user.Email,
                    UserName = user.UserName
                };
            }
            else
            {
                throw new Exception("User not found");
            }


        }
        public async Task<ResetPasswordResponseDTO> ResetPasswordAsync(ResetPasswordRequestDTO request)
        {
            User userExist = await authRepository.GetByIdAsync(request.UserId);
            if (userExist == null)
            {
                throw new Exception("User not Found");
            }
            else
            {
                userExist.Password = request.NewPassword;
                var updateUser = await authRepository.Update(userExist);
                return new ResetPasswordResponseDTO
                {
                    UserName = userExist.UserName,
                    Email = userExist.Email,
                };
            }
        }
        public async Task<RegisterResponseDTO> CreateUserAsync(RegisterRequestDTO request)
        {
            var existingEmail = await authRepository.FindByEmailAsync(request.Email);
            if (existingEmail == null)
            {
                User user = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = request.Password,
                    Active = true,
                    CreatedAt = System.DateTime.Now,
                };

                User newUser = await authRepository.Create(user);

                var defaultRole = await roleRepository.GetByName();
                if (defaultRole != null)
                {
                    var userRole = new UserRole
                    {
                        UserId = newUser.GlobalId,
                        RoleId = defaultRole.GlobalId,
                        Active = true,
                        CreatedAt = System.DateTime.Now
                    };
                    await userRoleRepository.Create(userRole);

                }
                return new RegisterResponseDTO
                {
                    UserId = newUser.GlobalId,
                    UserName = newUser.UserName,
                    Email = newUser.Email,
                    CreatedAt = newUser.CreatedAt,
                    Role = defaultRole.RoleName,
                    Active = true,
                };
            }
            else
            {
                throw new Exception("User with this Email already Exist Choose another one");
            }
        }

        private async Task<string> GenerateToken(User user, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Email", user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return await Task.FromResult(tokenString);
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                ValidIssuer = config["JWT:Issuer"],
                ValidAudience = config["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (!(securityToken is JwtSecurityToken jwtSecurityToken) ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        public async Task<AuthResponseDTO> RefreshTokenAsync(RefreshTokenRequestDTO request)
        {
            var principal = GetPrincipalFromExpiredToken(request.Token);
            var email = principal.FindFirstValue("Email");
            var user = await authRepository.GetUserByRefreshTokenAsync(request.RefreshToken);

            if (user == null || user.Email != email || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            var roles = await userRoleRepository.GetUserRolesAsync(user.GlobalId);
            var newToken = await GenerateToken(user, roles);
            var newRefreshToken = GenerateRefreshToken();
            await authRepository.SaveRefreshTokenAsync(user, newRefreshToken);

            return new AuthResponseDTO
            {
                JwtToken = newToken,
                RefreshToken = newRefreshToken
            };
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public async Task ForgotPasswordAsync(ForgotPasswordRequestDTO request)
        {
            var user = await authRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("No User Associated with this Email");
            }

            var otp = GenerateOtp();
            await authRepository.SaveResetPasswordOtpAsync(user, otp);

            await SendResetPasswordOtpEmail(user.Email, otp,user.UserName);
        }

        public async Task<string> VerifyOtpAsync(VerifyOtpRequestDTO request)
        {
            var user = await authRepository.GetUserByOtpAsync(request.Email, request.Otp);
            if (user == null)
            {
                throw new Exception("Invalid or expired OTP");
            }

            user.ResetPasswordOtp = null;
            user.ResetPasswordOtpExpiryTime = null;

            await authRepository.Update(user);
            return user.Email;
        }

        private async Task SendResetPasswordOtpEmail(string email, string otp,string name)
        {
            using (MailMessage ms = new MailMessage(config["SMTP:Username"], email))
            {
                ms.Subject = "Invitation Card Maker - OTP Verification";
                ms.Body = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f4;
                    color: #333;
                    padding: 20px;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    background-color: #fff;
                    padding: 20px;
                    border-radius: 8px;
                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                }}
                .header {{
                    text-align: center;
                    margin-bottom: 20px;
                }}
                .header h2 {{
                    color: #FC4468;
                }}
                .otp-container {{
                    text-align: center;
                    margin: 20px 0;
                }}
                .otp {{
                    display: inline-block;
                    padding: 10px 20px;
                    background-color: #FC4468;
                    color: #fff;
                    text-align: center;
                    border-radius: 5px;
                    font-size: 24px;
                    font-weight: bold;
                }}
                .footer {{
                    margin-top: 20px;
                    text-align: center;
                    font-size: 12px;
                    color: #aaa;
                }}
                .footer a {{
                    color: #007bff;
                    text-decoration: none;
                }}
                .footer a:hover {{
                    text-decoration: underline;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <h2>Invitation Card Maker</h2>
                    <p>OTP Verification</p>
                </div>
                <p>Hi {name},</p>
                <p>You recently requested to verify your account for your Invitation Card Maker account. Use the OTP below to proceed:</p>
                <div class='otp-container'>
                    <p class='otp'>{otp}</p>
                </div>
                <p>This OTP is only valid for the next 2 minutes.</p>
                <p>If you did not request an OTP, please ignore this email or <a href='mailto:support@invitationcardmaker.com'>contact support</a> if you have questions.</p>
                <div class='footer'>
                    <p>&copy; {DateTime.Now.Year} Invitation Card Maker. All rights reserved.</p>
                </div>
            </div>
        </body>
        </html>";
                ms.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = config["SMTP:Host"];
                    smtp.EnableSsl = true;
                    NetworkCredential crd = new NetworkCredential(config["SMTP:Username"], config["SMTP:Password"]);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = crd;
                    smtp.Port = int.Parse(config["SMTP:Port"]);
                    await smtp.SendMailAsync(ms);
                }
            }
        }

        private string GenerateOtp()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int value = BitConverter.ToInt32(randomNumber, 0) % 10000;
                return Math.Abs(value).ToString("D4");
            }

        }
        public async Task<string> ConfirmPassword(ConfirmPasswordRequestDTO request)
        {
            var updatedUser = await authRepository.UpdatePassword(request.Email, request.NewPassword);
            if (updatedUser != null)
            {
                return "Updated Successfuly";
            }
            else
            {
                throw new Exception("User with that email not found");
            }
        }



    }
}

