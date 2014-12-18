namespace Cqrs.Rest
{
	public interface IProcessQuery
	{
		TResult Execute<TResult>(IQueryRequest<TResult> query);
	}
}