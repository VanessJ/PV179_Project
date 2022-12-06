using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
using Bazaar.BL.Dtos.Ad;
using AutoMapper;
using Bazaar.BL.QueryObjects.Base;
using Optional.Unsafe;

namespace Bazaar.BL.QueryObjects.Ads
{
    public class AdQueryObject : BaseQueryObject<AdListDto, AdFilterDto, Ad, IQuery<Ad>>, IAdQueryObject
    {
        public AdQueryObject(IMapper mapper, IQuery<Ad> query) : base(mapper, query) { }

        public override IQuery<Ad> FilterByWhere(IQuery<Ad> query, AdFilterDto filterDto)
        {
            if (filterDto.ContainsTitleName.HasValue)
            {
                query.Filter(a => a.Title.Equals(filterDto.ContainsTitleName.ValueOrDefault()));
            }
            if (filterDto.LikeTitleName.HasValue)
            {
                query.Filter(a => a.Title.Contains(filterDto.LikeTitleName.ValueOrDefault()));
            }

            if (filterDto.ContainsInDescription.HasValue)
            {
                query.Filter(a => a.Description.Contains(filterDto.ContainsInDescription.ValueOrDefault()));
            }

            if (filterDto.UserId.HasValue)
            {
                query.Filter(a => a.UserId == filterDto.UserId.ValueOrDefault());
            }

            if (filterDto.TagNames.HasValue)
            {
                //query.Filter(a => a.AdTags.Any(tag => filterDto.TagNames.ValueOrDefault().Contains(tag.TagName)));
            }

            if (filterDto.MaxPrice > 0)
            {
                query.Filter(a => a.Price < filterDto.MaxPrice);
            }

            if (filterDto.MinPrice > 0)
            {
                query.Filter(a => a.Price > filterDto.MinPrice);
            }

            if (filterDto.OnlyValid)
            {
                query.Filter(a => a.IsValid);
            }

            if (filterDto.OnlyOffer)
            {
                query.Filter(a => a.IsOffer);
            }
            if (filterDto.OnlyDemand)
            {
                query.Filter(a => !a.IsOffer);
            }

            return query;
        }
    }
}
