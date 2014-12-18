namespace Cqrs.Rest
{

	public interface IHandleCommand<in TCommand> 
	{
		void Handle(TCommand command);
	}

	public interface IHandleCommand<in TCommand, out TResult> where TCommand : ICommandRequest<TResult>
	{
		TResult Handle(TCommand command);
	}
}