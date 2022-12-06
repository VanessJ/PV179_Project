using AutoMapper;
using Bazaar.App.Models;
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

        public TagController(ITagService tagService, IAdminFacade admin, IMapper mapper)
        {
            _tagService = tagService;
            _adminFacade = admin;
            _mapper = mapper;
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
