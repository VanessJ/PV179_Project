using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.BL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Base;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Review;
using Bazaar.BL.Dtos.Tag;
using Bazaar.Infrastructure.Query;
using Bazaar.BL.Dtos.User;

namespace Bazaar.BL.Config
{
    public class BusinessMapperConfig
    {
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Ad, AdCreateDto>().ReverseMap();
            config.CreateMap<Ad, AdDto>().ReverseMap();
            config.CreateMap<Ad, AdEditDto>().ReverseMap();
            //config.CreateMap<Ad, AdListDto>().ReverseMap();

            config.CreateMap<Image, ImageCreate>().ReverseMap();
            config.CreateMap<Image, ImageDto>().ReverseMap();

            config.CreateMap<Reaction, ReactionCreateDto>().ReverseMap();
            config.CreateMap<Reaction, ReactionDto>().ReverseMap();

            config.CreateMap<Review, ReviewCreateDto>().ReverseMap();
            config.CreateMap<Review, ReviewDto>().ReverseMap();

            config.CreateMap<Tag, TagCreateDto>().ReverseMap();
            config.CreateMap<Tag, TagDto>().ReverseMap();
            //config.CreateMap<Tag, TagListDto>().ReverseMap();

            config.CreateMap<User, UserCreateDto>().ReverseMap();
            config.CreateMap<User, UserDto>().ReverseMap();
            config.CreateMap<User, UserEditDto>().ReverseMap();
            //config.CreateMap<User, UserListDto>().ReverseMap();
        }
    }
}
