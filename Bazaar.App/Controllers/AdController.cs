using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Base;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Facade;
using Bazaar.BL.Services.Tags;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Optional;
using System.Security.Authentication;
using System.Security.Claims;

namespace Bazaar.App.Controllers
{
    public class AdController : Controller
    {
        private readonly IAdFacade _adFacade;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;


        public AdController(IAdFacade adFacade, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _adFacade = adFacade;
            _mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var filterDto = new AdFilterDto() { OderCriteria = "IsPremium".Some(), OrderAscending = false.Some() };

            var model = new AdIndexViewModel()
            {
                Tags = await _adFacade.GetAllTags(),
                Ads = await _adFacade.FilterAds(filterDto),
                MaxPrice = await _adFacade.GetHigherPrice()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdIndexViewModel model)
        {
            var filterDto = new AdFilterDto()
            {
                OderCriteria = "IsPremium".Some(),
                OrderAscending = false.Some(),
                LikeTitleName = OptionExtensions.SomeNotNull(model.LikeTitleName!),
                MinPrice = model.MinPrice,
                MaxPrice = model.MaxPrice,
                TagIds = model.TagIds.Some()
            };
            switch (model.TypeOfAd)
            {
                case "Demand":
                    filterDto.OnlyDemand = true;
                    break;
                case "Offer":
                    filterDto.OnlyOffer = true;
                    break;
            }

            model = new AdIndexViewModel()
            {
                Tags = await _adFacade.GetAllTags(),
                Ads = await _adFacade.FilterAds(filterDto),
                MaxPrice = await _adFacade.GetHigherPrice(),
                LikeTitleName = model.LikeTitleName,
                TagIds = model.TagIds
            };
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {

            string? idStr = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (idStr == null)
            {
                throw new AuthenticationException();
            }

            Guid currentUserId = new Guid(idStr);

            var dto = await _adFacade.AdDetail(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<AdDetailViewModel>(dto);
            if (true)
            {
                model.Reactions = await _adFacade.GetAdReactions(id);
            }
            return View(model);
        }

        public async Task<ActionResult> React(Guid id)
        {
            string? idStr = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (idStr == null)
            {
                throw new AuthenticationException();
            }

            Guid currentUserId = new Guid(idStr);

            var ad = await _adFacade.AdDetail(id);
            if (ad.Creator.Id == currentUserId)
            {
                return BadRequest();
            }

            var model = new ReactionCreateViewModel()
            {
                UserId = currentUserId,
                AdId = id
            };
            return View(model);
        }


        public async Task<ActionResult> RejectReaction(Guid adId, Guid reactionId)
        {
            string? idStr = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (idStr == null)
            {
                throw new AuthenticationException();
            }

            Guid currentUserId = new Guid(idStr);

            var ad = await _adFacade.AdDetail(adId);
            if (ad.Creator.Id == currentUserId)
            {
                return BadRequest();
            }

            await _adFacade.DeclineAdReaction(reactionId);

            return RedirectToAction("Details", new { id = adId });
        }

        public async Task<ActionResult> AcceptReaction(Guid adId, Guid reactionId)
        {
            string? idStr = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (idStr == null)
            {
                throw new AuthenticationException();
            }

            Guid currentUserId = new Guid(idStr);

            var ad = await _adFacade.AdDetail(adId);
            if (ad.Creator.Id == currentUserId)
            {
                return BadRequest();
            }

            await _adFacade.AcceptAdReaction(reactionId, adId);

            return RedirectToAction("Details", new { id = adId });
        }


        [HttpPost]
        public async Task<IActionResult> React(ReactionCreateViewModel model)
        {
            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            var dto = _mapper.Map<ReactionCreateDto>(model);
            await _adFacade.AddReaction(dto);
            return RedirectToAction(nameof(Index));
        }

            public async Task<IActionResult> Add()
        {
            var model = new AdCreateViewModel();
            var tags = await _adFacade.GetAllTags();
            var tagList = tags.ToList();
            model.AllTags = tagList;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdCreateViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var tags = await _adFacade.GetAllTags();
                var tagList = tags.ToList();
                model.AllTags = tagList;
                return View(model);
            }
            var dto = _mapper.Map<AdCreateDto>(model);
            var imgDtos = UploadImages(model.Files);
            
            await _adFacade.AddNewAdAsync(new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633"), imgDtos, model.TagIds, dto);
            return RedirectToAction(nameof(Index));
        } 

        public ICollection<ImageCreateDto> UploadImages(IEnumerable<IFormFile> files)
        {
            ICollection<ImageCreateDto> imageDtos = new List<ImageCreateDto>();
            
            if (files != null)
            {
                foreach (var img in files)
                {
                    if (img.Length > 0 && img.ContentType.Contains("image"))
                    {
                        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var filestream = new FileStream(filePath, FileMode.Create))
                        {
                            img.CopyTo(filestream);
                            var imgDto = new ImageCreateDto { Url = filePath, Title = ""};
                            imageDtos.Add(imgDto);
                        }
                    }
                }
            }

            return imageDtos;
        }



    }
}
