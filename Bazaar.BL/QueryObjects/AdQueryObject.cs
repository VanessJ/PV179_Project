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
                return query.Filter(a => a.Title.Equals(filterDto.ContainsTitleName));
            }
            if (!string.IsNullOrWhiteSpace(filterDto.LikeTitleName))
            {
                return query.Filter(a => a.Title.Contains(filterDto.LikeTitleName));
            }
            if (!(filterDto.UserId.HasValue || filterDto.UserId.Value == Guid.Empty))
            {
                return query.Filter(a => a.Title.Contains(filterDto.LikeTitleName));
            }

            if (!(filterDto.TagNames.Any() || filterDto.TagNames == null))
            {
                return query.Filter(a => a.AdTag.Any(at => filterDto.TagNames.Contains(at.Tag.TagName)));
            }

            return query;
        }
    }
}
