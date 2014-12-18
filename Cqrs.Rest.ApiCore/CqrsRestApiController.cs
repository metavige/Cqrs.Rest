using Cqrs.Rest;
using Microsoft.Practices.ServiceLocation;

namespace System.Web.Http
{
    /// <summary>
    /// ApiController 的基礎類別，目前僅提供部分與專案架構有關的屬性存取 不再提供介面實作
    /// </summary>
    public abstract class CqrsRestApiController : ApiController
    {
        public IProcessQuery QueryProcessor
        {
            get { return ServiceLocator.Current.GetInstance<IProcessQuery>(); }
        }

        public RestServiceHandler RestServiceHandler
        {
            get { return ServiceLocator.Current.GetInstance<RestServiceHandler>(); }
        }
    }
}