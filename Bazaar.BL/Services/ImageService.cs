using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.BL.Services
{
    public class ImageService : CRUDService<Image>
    {
        public ImageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }
}
