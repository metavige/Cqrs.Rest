namespace Cqrs.Rest
{
    public abstract class BaseIdQueryRequest<TIdentity, TResult> : IQueryRequest<TResult>
    {
        public TIdentity Id { get; set; }
    }
    
}
