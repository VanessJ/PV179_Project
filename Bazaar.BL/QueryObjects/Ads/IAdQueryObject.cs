using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.QueryObjects.Base;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.QueryObjects.Ads
{
    public interface IAdQueryObject : IBaseQueryObject<AdListDto, AdFilterDto, Ad, IQuery<Ad>>
    {
        IQuery<Ad> FilterByWhere(IQuery<Ad> query, AdFilterDto filterDto);
    }
}
