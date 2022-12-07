using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;

namespace Bazaar.App.Config
{
    public class BusinessMapperConfig : Profile
    {
        public BusinessMapperConfig()
        {
            CreateMap<Ad, AdCreateDto>().ReverseMap();
            CreateMap<Ad, AdDto>().ReverseMap();
            CreateMap<Ad, AdDetailDto>().ReverseMap();
            CreateMap<Ad, AdEditDto>().ReverseMap();
            CreateMap<Ad, AdListDto>().ReverseMap();

            CreateMap<AdTag, AdTagDto>().ReverseMap();

            CreateMap<Image, ImageCreateDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();

            CreateMap<Reaction, ReactionCreateDto>().ReverseMap();
            CreateMap<Reaction, ReactionDto>().ReverseMap();

            CreateMap<Review, ReviewCreateDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();

            CreateMap<Tag, TagCreateDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, TagListDto>().ReverseMap();

            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserEditDto>().ReverseMap();
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserProfileDetailDto>();
        }
    }
}
