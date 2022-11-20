using Bazaar.BL.Dtos.Base;
using Bazaar.DAL.Models;
using Bazaar.Infrastructure.Query;

namespace Bazaar.BL.QueryObjects.Base
{
    public interface IBaseQueryObject<TDto, TFilter, TEntity, TQuery>
        where TFilter : BaseFilterDto
        where TEntity : BaseEntity, new()
    {
        Task<IEnumerable<TDto>> ExecuteQueryAsync(TFilter filterDto);
        IQuery<TEntity> FilterByWhere(IQuery<TEntity> query, TFilter filterDto);
    }
}