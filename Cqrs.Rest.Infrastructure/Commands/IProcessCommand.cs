namespace Cqrs.Rest
{
	public interface IProcessCommand
	{
        void Execute(ICommandRequest command);

        TResult Execute<TResult>(ICommandRequest<TResult> command);
	}

}