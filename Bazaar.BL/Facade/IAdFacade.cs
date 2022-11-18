﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazaar.BL.Dtos.Ad;
using Bazaar.BL.Dtos.Image;
using Bazaar.BL.Dtos.Reaction;
using Bazaar.BL.Dtos.Tag;

namespace Bazaar.BL.Facade
{
    public interface IAdFacade
    {
        Task AddNewAdAsync(Guid userId, IEnumerable<ImageCreateDto> imageCreateDtos, IEnumerable<Guid> tagIdS, AdCreateDto adCreateDto);

        Task<AdDetailDto> AdDetail(Guid id);

        Task<AdOwnerDetailDto> AdDetailForOwner(Guid id);

        Task<IEnumerable<ReactionDto>> GetAdReactions(Guid id);

        Task AcceptAdReaction(Guid reactionId, Guid adId);

        Task DeleteAd(Guid id);

        Task EditAd(AdEditDto dto);

        Task<IEnumerable<AdListDto>> FilterAds(AdFilterDto filterDto);
        Task Browse();
    } 
}
