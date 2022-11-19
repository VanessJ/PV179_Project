using AutoMapper;
using Bazaar.BL.Dtos;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.Dtos.User;
using Bazaar.BL.QueryObjects;
using Bazaar.BL.Services.CRUDServices;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using Optional;

namespace Bazaar.BL.Services.Tags
{
    public class TagService : CRUDService<Tag>, ITagService
    {
        private readonly TagQueryObject _tagQueryObject;
        public TagService(IUnitOfWork unitOfWork, IMapper mapper, TagQueryObject tagQueryObject) : base(unitOfWork, mapper)
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

        public async Task<IEnumerable<AdDto>> GetAllAdsWithTag(Guid id)
        {
            var tag = await GetByIdAsync<TagDto>(id, nameof(Tag.Ads));
            return tag.Ad;
        }


    }
}
