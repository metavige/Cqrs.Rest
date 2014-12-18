namespace Cqrs.Rest
{
	public interface IHandleQuery<in TQuery, out TResult> where TQuery : IQueryRequest<TResult>
	{
		TResult Handle(TQuery query);
	}
}