namespace Cqrs.Rest
{
    public abstract class BaseIdCommandRequest<T> : ICommandRequest
    {
        public T Id { get; set; }
    }
}
