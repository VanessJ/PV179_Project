using AutoMapper;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Tag;
using Bazaar.BL.QueryObjects;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar.BL.Services.Tags
{
    public interface ITagService
    {

        public Task<IEnumerable<TagListDto>> GetTagsByName(string tagName);

        public Task<IEnumerable<TagListDto>> ExecuteQueryAsync(TagFilterDto filterDto);

        public Task<IEnumerable<AdDto>> GetAllAdsWithTag(Guid id);

    }
}
