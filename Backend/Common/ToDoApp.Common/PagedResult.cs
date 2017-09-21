using System;
using System.Collections.Generic;

namespace ToDoApp.Common
{
    /// <summary>
    /// Used for pagination when returning lists. Used in multiple Bounded contexts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Current page no being shown on the UI
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// How many elements in a single page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Number of pages in one result
        /// </summary>
        public int PageCount { get; private set; }

        /// <summary>
        /// Total number of records in the database for that entity
        /// </summary>
        public long TotalRecordCount { get; set; }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="items"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecordCount"></param>
        public PagedResult(IEnumerable<T> items, int pageNo, int pageSize, long totalRecordCount)
        {
            Items = new List<T>(items);

            PageNo = pageNo;
            PageSize = pageSize;
            TotalRecordCount = totalRecordCount;

            PageCount = totalRecordCount > 0
                ? (int)Math.Ceiling(totalRecordCount / (double)PageSize)
                : 0;
        }

        /// <summary>
        /// Items in the result
        /// </summary>
        public List<T> Items { get; set; }
    }
}
