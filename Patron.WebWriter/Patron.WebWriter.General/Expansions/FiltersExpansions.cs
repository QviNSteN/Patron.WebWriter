using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Patron.WebWriter.Data.Entity;
using Patron.WebWriter.Data.Filters;

namespace Patron.WebWriter.General.Expansions
{
    public static class FiltersExpansions
    {
        private static IQueryable<T> BaseFilter<T>(this IQueryable<T> entity, BaseFilter filter) where T : Base2
        {
            entity = entity.Skip(filter.Page * filter.Count);
            entity = entity.Take(filter.Count);

            return entity.OrderByDescending(x => x.CreatedDate);
        }

        private static IEnumerable<TElement> BaseFilter<Tkey, TElement>(this IGrouping<Tkey, TElement> entity, BaseFilter filter) where TElement : Base2
        {
            var result = entity.Skip(filter.Page * filter.Count);
            result = result.Take(filter.Count);

            return result.OrderByDescending(x => x.CreatedDate);
        }

        private static async Task<IList<T>> BaseFilterToListAsync<T>(this IQueryable<T> entity, BaseFilter filter) where T : Base2
        {
            return await entity.BaseFilter(filter).ToListAsync();
        }
    }
}