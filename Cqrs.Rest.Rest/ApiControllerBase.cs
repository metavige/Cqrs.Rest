using Microsoft.Practices.ServiceLocation;
using System.Web.Http;

namespace Cqrs.Rest
{
    /// <summary>
    /// ApiController 的基礎類別，目前僅提供部分與專案架構有關的屬性存取 不再提供介面實作
    /// </summary>
    public abstract class ApiControllerBase : ApiController
    {
        //public IProcessCommand CommandProcessor
        //{
        //    get { return ServiceLocator.Current.GetInstance<IProcessCommand>(); }
        //}
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