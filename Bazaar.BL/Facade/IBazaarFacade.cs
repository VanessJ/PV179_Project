using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.BL.Facade
{
    public interface IBazaarFacade
    {
        Task AddNewAdd(IEnumerable<ImageCreateDto> imageDtos, IEnumerable<TagCreateDto> tagDtos, AdCreateDto adCreateDto);
        Task Browse();
    } 
}
