﻿using Bazaar.BL.Dtos.AdTag;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Services.CRUDServices;

namespace Bazaar.BL.Services.Tags
{
    public interface ITagService : ICRUDService
    {

        public Task<IEnumerable<TagListDto>> GetTagsByName(string tagName);

        public Task<IEnumerable<TagListDto>> ExecuteQueryAsync(TagFilterDto filterDto);

        public Task<IEnumerable<AdTagDto>> GetAllAdsWithTag(Guid id);

    }
}
