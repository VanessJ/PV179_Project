using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
using Bazaar.BL.Dtos.Ad;
using AutoMapper;


namespace Bazaar.BL.QueryObjects
{
    public class AdQueryObject : BaseQueryObject<AdListDto, AdFilterDto, Ad, IQuery<Ad>>
    {
        public AdQueryObject(IMapper mapper, IQuery<Ad> query) : base(mapper, query) { }

        protected override IQuery<Ad> FilterByWhere(IQuery<Ad> query, AdFilterDto filterDto)
        {
            if (!string.IsNullOrWhiteSpace(filterDto.ContainsTitleName))
            {
                query = query.Filter(a => a.Title.Equals(filterDto.ContainsTitleName));
            }
            if (!string.IsNullOrWhiteSpace(filterDto.LikeTitleName))
            {
                query.Filter(a => a.Title.Contains(filterDto.LikeTitleName));
            }

            if (!string.IsNullOrWhiteSpace(filterDto.ContainsInDescription))
            {
                query.Filter(a => a.Description.Contains(filterDto.ContainsInDescription));
            }

            if (!(!filterDto.UserId.HasValue || filterDto.UserId.Value == Guid.Empty))
            {
                query.Filter(a => a.UserId == filterDto.UserId);
            }

            if (filterDto.TagNames != null)
            {
                return query.Filter(a => a.Tags.Any(tag => filterDto.TagNames.Contains(tag.TagName)));
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
                query.Filter((a => a.IsValid));
            }
            
            if (filterDto.OnlyOffer)
            {
                query.Filter((a => a.IsOffer));
            }
            if (filterDto.OnlyDemand)
            {
                query.Filter(a => !a.IsOffer);
            }
            
            return query;
        }
    }
}
