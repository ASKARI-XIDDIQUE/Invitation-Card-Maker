using AutoMapper;
using Invitation_Card_Maker.DTO.RequestDTO;
using Invitation_Card_Maker.DTO.ResponseDTO;
using Invitation_Card_Maker.Models;

namespace Invitation_Card_Maker.Mappers.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequestDTO, Category>()
                .ForMember(des => des.Name, opt => opt.MapFrom(ct => ct.CategoryName)).ReverseMap();
            CreateMap<CategoryResponseDTO, Category>()
                .ForMember(des => des.Name, opt => opt.MapFrom(ct => ct.CategoryName)).ReverseMap();
        }
    }
}
