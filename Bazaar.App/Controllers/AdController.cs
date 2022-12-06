using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Facade;
using Bazaar.BL.Services.Tags;
using Microsoft.AspNetCore.Mvc;

namespace Bazaar.App.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdFacade _adFacade;
        private readonly IMapper _mapper;

        public AdController(IAdFacade adFacade, IMapper mapper)
        {
            _adFacade = adFacade;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var dto = new AdFilterDto();
            var model = new AdIndexViewModel()
            {
                
                Ads = await _adFacade.FilterAds(dto)
            };
            return View(model);
        }
    }
}
