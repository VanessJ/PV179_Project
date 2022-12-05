using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.QueryObjects.Base;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Query;

namespace Bazaar.BL.QueryObjects.Tags
{
    public interface ITagQueryObject : IBaseQueryObject<TagListDto, TagFilterDto, Tag, IQuery<Tag>>
    {
        IQuery<Tag> FilterByWhere(IQuery<Tag> query, TagFilterDto filterDto);
    }
}
