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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bazaar.BL.QueryObjects
{
    public abstract class BaseQueryObject<TDto, TFilter, TEntity, TQuery>
        where TEntity : BaseEntity, new()
        where TFilter : BaseFilterDto
        where TQuery : IQuery<TEntity>
        
    {
        protected readonly IMapper _mapper;
        protected readonly IQuery<TEntity> _query;
 

        protected BaseQueryObject(IMapper mapper, TQuery query)
        {
            this._mapper = mapper;
            this._query = query;
        }
        protected abstract IQuery<TEntity> FilterByWhere(IQuery<TEntity> query, TFilter filterDto);

        public async Task<IEnumerable<TDto>> ExecuteQueryAsync(TFilter filterDto)
        {
            var query = FilterByWhere(_query, filterDto);

            if (!string.IsNullOrWhiteSpace(filterDto.OderCriteria))
            {
                query.OrderBy(x => EF.Property<object>(x, filterDto.OderCriteria));
            }

            if (filterDto.RequestedPageNumber.HasValue)
            {
                query = query.Page(filterDto.RequestedPageNumber.Value, filterDto.PageSize);
            }

            var resultQuery = await query.ExecuteAsync();

            return _mapper.Map<IEnumerable<TDto>>(resultQuery);
        
        }
    }
}
