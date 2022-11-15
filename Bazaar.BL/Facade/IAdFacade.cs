using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Ad;

namespace Bazaar.BL.Facade
{
    public interface IAdFacade
    {
        Task AddNew(Guid userId, IEnumerable<Guid> imageIds, IEnumerable<Guid> tagIds, AdCreateDto adCreateDto);
        Task Browse();
    } 
}
