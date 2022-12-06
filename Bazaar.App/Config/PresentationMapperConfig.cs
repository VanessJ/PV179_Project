using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.App.Config
{
    public class PresentationMapperConfig : Profile
    {
        public PresentationMapperConfig()
        {
            CreateMap<TagEditDto, TagEditViewModel>().ReverseMap();
            CreateMap<TagCreateDto, TagCreateViewModel>().ReverseMap();
            CreateMap<AdDetailDto, AdDetailViewModel>().ReverseMap();
        }
    }
}
