using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Facade;
using Bazaar.BL.Services.Tags;
using Microsoft.AspNetCore.Mvc;

namespace Bazaar.App.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IAdminFacade _adminFacade;
        private readonly IMapper _mapper;
        private readonly IAdFacade _adFacade;

        public TagController(ITagService tagService, IAdminFacade admin, IMapper mapper, IAdFacade adFacade)
        {
            _tagService = tagService;
            _adminFacade = admin;
            _mapper = mapper;
            _adFacade = adFacade;
        }

        public async Task<IActionResult> Index()
        {
            var model = new TagIndexViewModel()
            {
                Tags = await _tagService.GetAllAsync<TagListDto>()
            };
            return View(model);
        }

        public IActionResult Add()
        {
            return View(new TagCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TagCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<TagCreateDto>(model);
            await _adminFacade.AddNewTag(dto);

            await _adFacade.AddNewAdAsync(new Guid("40678c71-cd5f-4a6c-bd00-442da8a88591"), new List<ImageCreateDto>(),
                new List<Guid>()
                {
                    new Guid("c252e554-01cc-44d4-8e9e-9df9be57c9c6"), new Guid("3a9e071f-4c7b-467a-8e25-d0293c9c45cf")
                }, new AdCreateDto() {Title = "TOTO JE MOJA PONUKA", Description = "HALO"});

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var dto = await _tagService.GetByIdAsync<TagEditDto>(id);
            if (dto == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<TagEditViewModel>(dto);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TagEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = _mapper.Map<TagEditDto>(model);
            await _adminFacade.UpdateTag(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dto = await _tagService.GetByIdAsync<TagDto>(id);
            if (dto == null)
            {
                return NotFound();
            }

            await _adminFacade.DeleteTag(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
