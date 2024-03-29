﻿using AutoMapper;
using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.QueryObjects.Tags;
using Bazaar.BL.Services.CRUDServices;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using Optional;

namespace Bazaar.BL.Services.Tags
{
    public class TagService : CRUDService<Tag>, ITagService
    {
        private readonly ITagQueryObject _tagQueryObject;
        public TagService(IUnitOfWork unitOfWork, IMapper mapper, ITagQueryObject tagQueryObject) : base(unitOfWork, mapper)
        {
            _tagQueryObject = tagQueryObject;

        }
        public async Task<IEnumerable<TagListDto>> GetTagsByName(string tagName)
        {
            return await _tagQueryObject.ExecuteQueryAsync(new TagFilterDto { ContainsTagName = tagName.Some() });
        }

        public async Task<IEnumerable<TagListDto>> ExecuteQueryAsync(TagFilterDto filterDto)
        {
            return await _tagQueryObject.ExecuteQueryAsync(filterDto);
        }

        public async Task<IEnumerable<AdTagDto>> GetAllAdsWithTag(Guid id)
        {
            var tag = await GetByIdAsync<TagDto>(id, nameof(Tag.AdTags));
            return tag.AdTags;
        }


    }
}
