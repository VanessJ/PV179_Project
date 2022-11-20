using AutoMapper;
using Bazaar.BL.Dtos.Base;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Optional.Unsafe;

namespace Bazaar.BL.QueryObjects.Base
{
    public abstract class BaseQueryObject<TDto, TFilter, TEntity, TQuery> : IBaseQueryObject<TDto, TFilter, TEntity, TQuery>
        where TEntity : BaseEntity, new()
        where TFilter : BaseFilterDto
        where TQuery : IQuery<TEntity>

    {
        protected readonly IMapper _mapper;
        protected readonly IQuery<TEntity> _query;


        protected BaseQueryObject(IMapper mapper, TQuery query)
        {
            _mapper = mapper;
            _query = query;
        }
        public abstract IQuery<TEntity> FilterByWhere(IQuery<TEntity> query, TFilter filterDto);

        public async Task<IEnumerable<TDto>> ExecuteQueryAsync(TFilter filterDto)
        {
            var query = FilterByWhere(_query, filterDto);

            if (filterDto.OderCriteria.HasValue)
            {
                query.OrderBy(filterDto.OderCriteria.ValueOrDefault(), filterDto.OrderAscending.ValueOr(true));
            }

            if (filterDto.RequestedPageNumber.HasValue && filterDto.PageSize.HasValue)
            {
                query.Page(filterDto.RequestedPageNumber.ValueOrDefault(), filterDto.PageSize.ValueOrDefault());
            }

            var resultQuery = await query.ExecuteAsync();

            return _mapper.Map<IEnumerable<TDto>>(resultQuery);

        }
    }
}
