namespace Cqrs.Rest
{
    /// <summary>
    /// CQRS 的 Query 介面
    /// </summary>
    /// <typeparam name="TResult">定義回傳值類型</typeparam>
    /// <remarks>
    /// 
    /// 這個介面只是用來作物件的分類，並沒有實際要實作的方法或屬性
    /// </remarks>
    public interface IQueryRequest<TResult>
    {
    }
}
