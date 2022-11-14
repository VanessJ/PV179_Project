using AutoMapper;
using Bazaar.BL.Dtos.Base;
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
        where TEntity : class, new()
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
        protected abstract IQuery<TEntity> FilterByWhere(IQuery<TEntity> query, TFilter filter_dto);

        public async Task<IEnumerable<TDto>> ExecuteQueryAsync(TFilter filter_dto)
        {
            var query = FilterByWhere(_query, filter_dto);

            if (!string.IsNullOrWhiteSpace(filter_dto.OderCriteria))
            {
                query.OrderBy(x => EF.Property<object>(x, filter_dto.OderCriteria));
            }

            if (filter_dto.RequestedPageNumber.HasValue)
            {
                query = query.Page(filter_dto.RequestedPageNumber.Value, filter_dto.PageSize);
            }

            var result_query = await query.ExecuteAsync();

            return _mapper.Map<IEnumerable<TDto>>(result_query);

        }
    }
}
