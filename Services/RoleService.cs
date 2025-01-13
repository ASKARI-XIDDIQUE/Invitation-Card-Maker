using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Interfaces.Repositories;
using Invitation_Card_Maker.Models;
using Invitation_Card_Maker.Repositories;

namespace Invitation_Card_Maker.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository= roleRepository;
        }
        public async Task<RoleResponseDTO> CreateAsync(RoleRequestDTO request)
        {


            Role role= new Role()
            {
                RoleName = request.RoleName,
                CreatedAt = DateTime.UtcNow,
                Active = true,
            };
            Role newRole = await _roleRepository.Create(role);
            RoleResponseDTO roleResponse = new RoleResponseDTO()
            {
                RoleName = newRole.RoleName,
                Active = newRole.Active,
                CreatedAt=newRole.CreatedAt
            };
            return roleResponse;




        }
        public async Task<List<RoleResponseDTO>> GetAllAsync()
        {
            List<Role> roles = await _roleRepository.Get();

            List<RoleResponseDTO> roleResponseDTOs =roles
                .Where(cat => cat.Active)
                .Select(cat => new RoleResponseDTO
                {
                    RoleId = cat.GlobalId,
                    RoleName = cat.RoleName,
                    Active = cat.Active,
                })
            .ToList();

            return roleResponseDTOs;
        }
        public async Task<RoleResponseDTO> UpdateAsync(RoleRequestDTO request)
        {
            Role existingRole = await _roleRepository.GetById(request.GlobalId);
            if (existingRole == null)
            {
                throw new Exception("Role not Found");
            }
            else
            {
                existingRole.RoleName = request.RoleName;
                existingRole.UpdatedAt = System.DateTime.UtcNow;
                Role updatedRole = await _roleRepository.Update(existingRole);
                RoleResponseDTO roleResponseDTO = new RoleResponseDTO()
                {
                    RoleId = existingRole.GlobalId,
                    RoleName = existingRole.RoleName,
                    Active = existingRole.Active,
                };
                return roleResponseDTO;


            }
        }
        public async Task<bool> DeleteAsync(Guid request)
        {
            Role existingRole = await _roleRepository.GetById(request);
            if (existingRole == null)
            {
                throw new Exception("Role not Found");
            }
            else
            {
                existingRole.Active = false;
                existingRole.DeletedAt = System.DateTime.Now;
                await _roleRepository.Update(existingRole);
                return true;

            }
        }


    }
}
