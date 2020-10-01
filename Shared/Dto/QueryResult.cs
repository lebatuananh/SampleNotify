﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shared.Dto
{
    public class QueryResult<T>
    {
        public QueryResult()
        {
        }

        public QueryResult(long count, IEnumerable<T> items)
        {
            Count = count;
            Items = items;
        }

        public long Count { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        public static QueryResult<T> Empty()
        {
            return new QueryResult<T>(0, null);
        }
    }
    
    
    public static class QueryResultExtension
    {
        public static async Task<QueryResult<T>> ToQueryResultAsync<T>(this IQueryable<T> queryable, int skip, int take)
        {
            return new QueryResult<T>
            {
                Count = await queryable.CountAsync(),
                Items = await queryable.Skip(skip).Take(take).ToListAsync()
            };
        }

        public static QueryResult<K> Select<T, K>(this QueryResult<T> @this, Func<T, K> selector)
        {
            return new QueryResult<K>
            {
                Count = @this.Count,
                Items = @this.Items.Select(selector)
            };
        }
    }
}