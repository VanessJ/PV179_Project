using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;

namespace Bazaar.App.Config
{
    public class PresentationMapperConfig : Profile
    {
        public PresentationMapperConfig()
        {
            CreateMap<TagEditDto, TagEditViewModel>().ReverseMap();
            CreateMap<TagCreateDto, TagCreateViewModel>().ReverseMap();
            CreateMap<UserProfileDetailDto, UserDetailViewModel>().ReverseMap();
            CreateMap<AdDetailDto, AdDetailViewModel>().ReverseMap();
        }
    }
}
