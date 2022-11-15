using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bazaar.BL.Dtos.Tag;

using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;

namespace Bazaar.BL.QueryObjects
{
    public class TagQueryObject : BaseQueryObject<TagListDto, TagFilterDto, Tag, IQuery<Tag>>
    {
        public TagQueryObject(IMapper mapper, IQuery<Tag> query) : base(mapper, query) { }

        protected override IQuery<Tag> FilterByWhere(IQuery<Tag> query, TagFilterDto filter_dto)
        {
            if (!string.IsNullOrWhiteSpace(filter_dto.ContainsTagName))
            {
                return query.Filter(t => t.TagName.Equals(filter_dto.ContainsTagName));
            }
            if (!string.IsNullOrWhiteSpace(filter_dto.LikeTagName))
            {
                return query.Filter(t => t.TagName.Contains(filter_dto.LikeTagName));
            }

            return query;
        }
    }
}
