namespace Cqrs.Rest
{
    /// <summary>
    /// CQRS 的 Command 介面
    /// </summary>
    /// <remarks>
    /// 為了不與 Command Pattern 的 Command 搞混
    /// 所以把介面名稱改成 CommandRequest，代表是一個要求的概念
    /// 
    /// 這個介面只是用來作物件的分類，並沒有實際要實作的方法或屬性
    /// </remarks>
    public interface ICommandRequest
    {
    }

    public interface ICommandRequest<TResult>
    {
    }
}
