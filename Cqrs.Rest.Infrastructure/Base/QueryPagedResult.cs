using System.Collections.Generic;

namespace Cqrs.Rest
{
    public class QueryPagedResult<TResult> where TResult : class
    {
        /// <summary>
        /// 總筆數
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 參數物件，傳回給前端參考
        /// </summary>
        public IQueryRequest<QueryPagedResult<TResult>> Criteria { get; set; }
        /// <summary>
        /// 結果
        /// </summary>
        public IEnumerable<TResult> Result { get; set; }

    }
}
