using System;

namespace Cqrs.Rest
{
    /// <summary>
    /// 定義查詢相關的屬性
    /// </summary>
    public class QueryCriteriaModel
    {
        #region 查詢資料相關參數，主要是分頁屬性

        /// <summary>
        /// 第幾頁.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每頁筆數.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序欄位.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public string Sort { get; set; }
        /// <summary>
        /// 排序方式是否為降冪排序.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is descending; otherwise, <c>false</c>.
        /// </value>
        public string Order { get; set; }

        public bool IsDescending
        {
            get { return !string.Equals("asc", Order, StringComparison.CurrentCultureIgnoreCase); }
        }

        #endregion

    }
}
