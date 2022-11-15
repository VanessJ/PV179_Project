using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Facade
{
    interface IAdFacade
    {
        Task CreateNew(Guid userId);
        Task Browse();
    } 
}
