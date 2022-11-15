using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
using Bazaar.BL.Dtos.Ad;
using AutoMapper;


namespace Bazaar.BL.QueryObjects
{
    public class AdQueryObject : BaseQueryObject<AdListDto, AdFilterDto, Ad, IQuery<Ad>>
    {
        public AdQueryObject(IMapper mapper, IQuery<Ad> query) : base(mapper, query) { }

        protected override IQuery<Ad> FilterByWhere(IQuery<Ad> query, AdFilterDto filter_dto)
        {
            if (!string.IsNullOrWhiteSpace(filter_dto.ContainsTitleName))
            {
                return query.Filter(a => a.Title.Equals(filter_dto.ContainsTitleName));
            }
            if (!string.IsNullOrWhiteSpace(filter_dto.LikeTitleName))
            {
                return query.Filter(a => a.Title.Contains(filter_dto.LikeTitleName));
            }
            if (!(filter_dto.UserId.HasValue || filter_dto.UserId.Value == Guid.Empty))
            {
                return query.Filter(a => a.Title.Contains(filter_dto.LikeTitleName));
            }

            if (!(filter_dto.TagNames.Any() || filter_dto.TagNames == null))
            {
                return query.Filter(a => a.AdTag.Any(at => filter_dto.TagNames.Contains(at.Tag.TagName)));
            }

            return query;
        }
    }
}
