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

        protected override IQuery<Tag> FilterByWhere(IQuery<Tag> query, TagFilterDto filterDto)
        {
            if (!string.IsNullOrWhiteSpace(filterDto.ContainsTagName))
            {
                return query.Filter(t => t.TagName.Equals(filterDto.ContainsTagName));
            }
            if (!string.IsNullOrWhiteSpace(filterDto.LikeTagName))
            {
                return query.Filter(t => t.TagName.Contains(filterDto.LikeTagName));
            }

            return query;
        }
    }
}
