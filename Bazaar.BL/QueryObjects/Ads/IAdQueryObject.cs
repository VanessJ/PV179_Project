using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.QueryObjects.Base;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Query;

namespace Bazaar.BL.QueryObjects.Ads
{
    public interface IAdQueryObject : IBaseQueryObject<AdListDto, AdFilterDto, Ad, IQuery<Ad>>
    {
        IQuery<Ad> FilterByWhere(IQuery<Ad> query, AdFilterDto filterDto);
    }
}
