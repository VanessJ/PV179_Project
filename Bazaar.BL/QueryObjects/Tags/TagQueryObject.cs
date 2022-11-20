using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bazaar.BL.Dtos.Tag;

using Bazaar.Infrastructure.Query;
using Bazaar.DAL.Models;
<<<<<<< HEAD:Bazaar.BL/QueryObjects/Tags/TagQueryObject.cs
using Bazaar.BL.QueryObjects.Base;
=======
using Optional.Unsafe;
>>>>>>> 04a01617bf450eaf01d6e7a0c358d2c206072cee:Bazaar.BL/QueryObjects/TagQueryObject.cs

namespace Bazaar.BL.QueryObjects.Tags
{
    public class TagQueryObject : BaseQueryObject<TagListDto, TagFilterDto, Tag, IQuery<Tag>>, ITagQueryObject
    {
        public TagQueryObject(IMapper mapper, IQuery<Tag> query) : base(mapper, query) { }

        public override IQuery<Tag> FilterByWhere(IQuery<Tag> query, TagFilterDto filterDto)
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
