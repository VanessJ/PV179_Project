﻿using AutoMapper;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.UnitOfWork;

namespace Bazaar.BL.Services
{
    public class ReactionService : CRUDService<Reaction>
    {
        public ReactionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
    }
}