using AutoMapper;
using Microsoft.Practices.ServiceLocation;

namespace Cqrs.Rest
{
	public abstract class BaseQueryHandler<TQuery, TResult> : IHandleQuery<TQuery, TResult> 
        where TQuery : IQueryRequest<TResult>
	{
		#region IQueryHandler<TQuery,TResult> Members

		public abstract TResult Handle(TQuery query);

		#endregion

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
