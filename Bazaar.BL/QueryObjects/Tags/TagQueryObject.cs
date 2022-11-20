using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bazaar.BL.Dtos.Tag;

using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
using Bazaar.BL.QueryObjects.Base;

namespace Bazaar.BL.QueryObjects.Tags
{
    public class TagQueryObject : BaseQueryObject<TagListDto, TagFilterDto, Tag, IQuery<Tag>>, ITagQueryObject
    {
        public TagQueryObject(IMapper mapper, IQuery<Tag> query) : base(mapper, query) { }

        public override IQuery<Tag> FilterByWhere(IQuery<Tag> query, TagFilterDto filterDto)
        {
            if (!string.IsNullOrWhiteSpace(filterDto.ContainsTagName))
            {
                query.Filter(t => t.TagName.Equals(filterDto.ContainsTagName));
            }
            if (!string.IsNullOrWhiteSpace(filterDto.LikeTagName))
            {
                query.Filter(t => t.TagName.Contains(filterDto.LikeTagName));
            }

            return query;
        }
    }
}
