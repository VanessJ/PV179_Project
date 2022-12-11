using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;

namespace Bazaar.App.Config
{
    public class PresentationMapperConfig : Profile
    {
        public PresentationMapperConfig()
        {
            CreateMap<TagDto, TagEditViewModel>().ReverseMap();
            CreateMap<TagCreateDto, TagCreateViewModel>().ReverseMap();
            CreateMap<UserProfileDetailDto, UserDetailViewModel>().ReverseMap();
            CreateMap<AdDetailDto, AdDetailViewModel>().ReverseMap();
            CreateMap<AdCreateDto, AdCreateViewModel>().ReverseMap();
            CreateMap<ReactionCreateDto, ReactionCreateViewModel>().ReverseMap();
        }
    }
}
