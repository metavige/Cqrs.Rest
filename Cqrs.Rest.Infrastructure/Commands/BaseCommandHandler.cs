using AutoMapper;
using Microsoft.Practices.ServiceLocation;

namespace Cqrs.Rest
{
    public abstract class BaseCommandHandler<TCommand> : IHandleCommand<TCommand> where TCommand : ICommandRequest
    {

        #region Implementation of IHandleCommand<TCommand>

        public abstract void Handle(TCommand command);

        #endregion Implementation of IHandleCommand<TCommand>

        protected T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        /// <summary>
        /// 指定轉換型別，將 TSource 的物件轉成 TDest 的物件
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        protected TDest ConvertMap<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TSource, TDest>(source);
        }
    }

    public abstract class BaseCommandHandler<TCommand, TResult> : IHandleCommand<TCommand, TResult> where TCommand : ICommandRequest<TResult>
    {

        #region Implementation of IHandleCommand<TCommand>

        public abstract TResult Handle(TCommand command);

        #endregion Implementation of IHandleCommand<TCommand>

        protected T Resolve<T>()
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        /// <summary>
        /// 指定轉換型別，將 TSource 的物件轉成 TDest 的物件
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        protected TDest ConvertMap<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TSource, TDest>(source);
        }
    }
}