﻿using AutoMapper;
using Bazaar.App.Models;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Optional;

namespace Bazaar.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly IAdminFacade _adminFacade;
        private readonly IMapper _mapper;
        private readonly IAdFacade _adFacade;

        public TagController( IAdminFacade admin, IMapper mapper, IAdFacade adFacade)
        {
            _adminFacade = admin;
            _mapper = mapper;
            _adFacade = adFacade;
        }

        public async Task<IActionResult> Index(string likeTagName)
        {
            var filterDto = new TagFilterDto();
            filterDto.LikeTagName = OptionExtensions.SomeNotNull(likeTagName!);
            var model = new TagIndexViewModel()
            {
                Tags = await _adFacade.FilterTags(filterDto)
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
            var dto = await _adFacade.GetTagById(id);
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

            var dto = _mapper.Map<TagDto>(model);
            await _adminFacade.EditTag(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dto = await _adFacade.GetTagById(id);
            if (dto == null)
            {
                return NotFound();
            }

            await _adminFacade.DeleteTag(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
