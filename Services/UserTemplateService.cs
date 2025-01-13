using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invitation_Card_Maker.Services
{
    public class UserTemplateService
    {
        private readonly IUserTemplateRepository _userTemplateRepository;
        private readonly ITemplateRepository _templateRepository;
        private readonly IAuthRepository _userRepository;

        public UserTemplateService(IUserTemplateRepository userTemplateRepository, ITemplateRepository templateRepository, IAuthRepository userRepository)
        {
            _userTemplateRepository = userTemplateRepository;
            _templateRepository = templateRepository;
            _userRepository = userRepository;
        }
        public async Task<UserTemplateResponseDTO> CreateUserTemplateAsync(UserTemplateRequestDTO request)
        {
            var userTemplate = new UserTemplate
            {
                UserId = request.UserId,
                TemplateId = request.TemplateId,
                CreatedAt = DateTime.UtcNow,
                Active = true
            };

            await _userTemplateRepository.Create(userTemplate);

            var user = await _userRepository.GetByIdAsync(request.UserId);
            var templates = await _userTemplateRepository.GetTemplatesByUserId(request.UserId);

            var userTemplateResponse = new UserTemplateResponseDTO
            {
                UserId = user.GlobalId,
                UserName = user.UserName,
                TemplateResponseList = templates.Select(t => new TemplateResponseDTO
                {
                    GlobalId = t.GlobalId,
                    Active = t.Active,
                    CategoryId = t.CategoryId,
                    ImagePath = t.ImagePath,
                    Title = t.Title,
                    Description = t.Description,
                    Content = t.Content
                }).ToList()
            };

            return userTemplateResponse;
        }



        public async Task<List<UserTemplateResponseDTO>> GetUserTemplatesByUserIdAsync(Guid userId)
        {
            var userTemplates = await _userTemplateRepository.GetTemplatesByUserId(userId);
            var user = await _userRepository.GetByIdAsync(userId);

            var response = new List<UserTemplateResponseDTO>
            {
                new UserTemplateResponseDTO
                {
                    UserId = user.GlobalId,
                    UserName = user.UserName,
                    TemplateResponseList = userTemplates.Select(ut => new TemplateResponseDTO
                    {
                        GlobalId = ut.GlobalId,
                        Active = ut.Active,
                        CategoryId = ut.CategoryId,
                        ImagePath = ut.ImagePath,
                        Title = ut.Title,
                        Description = ut.Description,
                        Content = ut.Content
                    }).ToList()
                }
            };

            return response;
        }
    }
}
