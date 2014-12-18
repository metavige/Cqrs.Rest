using System;
using System.Linq;
using System.Linq.Expressions;
using Cqrs.Rest;

// ReSharper disable once CheckNamespace
namespace System.Linq
{
    public static class QueryableExtension
    {
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, string sSearch, Expression<Func<T, bool>> filter)
        {
            //Text Filter
            if (filter != null && !string.IsNullOrEmpty(sSearch))
                query = query.Where(filter);

            return query;
        }

        public static IQueryable<T> ApplyDateTimeFilter<T>(this IQueryable<T> query, DateTime? sSearch, Expression<Func<T, bool>> filter)
        {
            //Text Filter
            if (filter != null && sSearch.HasValue)
                query = query.Where(filter);

            return query;
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, decimal sSearch, Expression<Func<T, bool>> filter)
        {
            if (filter != null && sSearch != 0)
                query = query.Where(filter);

            return query;
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Guid? sSearch, Expression<Func<T, bool>> filter)
        {
            if (filter != null && sSearch.HasValue && sSearch != new Guid())
                query = query.Where(filter);

            return query;
        }

        //public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> data, int itemsDisplayed, int pageSize)
        //{
        //    if (pageSize > 0 && itemsDisplayed > 0)
        //        data = data.Skip(itemsDisplayed);

        //    data = data.Take(pageSize);

        //    return data;
        //}

        //public static IQueryable<T> ApplySorting<T>(this IQueryable<T> data, string sortDirection, Expression<Func<T, string>> orderingFunction)
        //{
        //    return sortDirection == "asc" ? data.OrderBy(orderingFunction) : data.OrderByDescending(orderingFunction);
        //}


        /// <summary>
        /// 透過 <see cref="EntitySorter"/>，作到動態屬性名稱的排序
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="criteria"></param>
        /// <param name="defaultKeySelector"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> SortByCriteria<TEntity, TKey>(this IQueryable<TEntity> source,
            QueryCriteriaModel criteria, Expression<Func<TEntity, TKey>> defaultKeySelector, bool isDescending = true)
        {
            IEntitySorter<TEntity> sorter;
            if (string.IsNullOrEmpty(criteria.Sort))
            {
                sorter = (isDescending)
                            ? EntitySorter<TEntity>.OrderByDescending(defaultKeySelector)
                            : EntitySorter<TEntity>.OrderBy(defaultKeySelector);
            }
            else
            {
                // 動態利用 EntitySorter 來排序~
                sorter = (criteria.IsDescending)
                     ? EntitySorter<TEntity>.OrderByDescending(criteria.Sort)
                     : EntitySorter<TEntity>.OrderBy(criteria.Sort);
            }

            var sortedResult = sorter.Sort(source);
            //Console.WriteLine(sortedResult.ToString());

            return sortedResult;
        }
    }
}
