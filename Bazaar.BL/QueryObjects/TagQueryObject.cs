using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bazaar.BL.Dtos.Tag;

using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
using Optional.Unsafe;

namespace Bazaar.BL.QueryObjects
{
    public class TagQueryObject : BaseQueryObject<TagListDto, TagFilterDto, Tag, IQuery<Tag>>
    {
        public TagQueryObject(IMapper mapper, IQuery<Tag> query) : base(mapper, query) { }

        protected override IQuery<Tag> FilterByWhere(IQuery<Tag> query, TagFilterDto filterDto)
        {
            if (filterDto.ContainsTagName.HasValue)
            {
                query.Filter(t => t.TagName.Equals(filterDto.ContainsTagName.ValueOrDefault()));
            }
            if (filterDto.LikeTagName.HasValue)
            {
                query.Filter(t => t.TagName.Contains(filterDto.LikeTagName.ValueOrDefault()));
            }

            return query;
        }
    }
}
