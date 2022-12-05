using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.App.Config
{
    public class PresentationMapperConfig : Profile
    {
        public PresentationMapperConfig()
        {
            CreateMap<TagIndexViewModel, TagListDto>().ReverseMap();
            CreateMap<TagInsertViewModel, TagCreateDto>().ReverseMap();
            CreateMap<TagEditViewModel, TagEditDto>().ReverseMap();
        }
    }
}
