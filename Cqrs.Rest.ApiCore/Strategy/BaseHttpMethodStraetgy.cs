﻿using System.Net.Http;
using System.Web.Http.Routing;
using Microsoft.Practices.ServiceLocation;

namespace Cqrs.Rest
{
    /// <summary>
    /// HttpMethodStrategy Base 類別.
    /// </summary>
    public abstract class BaseHttpMethodStraetgy : IRestfulStrategy
    {
        #region Fields & properties

        private UrlHelper _urlHelper;

        public HttpRequestMessage HttpRequest { get; private set; }

        public UrlHelper Url
        {
            get
            {
                return _urlHelper ?? (_urlHelper = HttpRequest.GetUrlHelper());
            }
        }

        //public IUnityContainer Container
        //{
        //    get { return ServiceLocator.Current.GetInstance<IUnityContainer>(); }
        //}

        public IProcessCommand CommandProcessor {
            get { return ServiceLocator.Current.GetInstance<IProcessCommand>(); }
        }

        #endregion

        protected BaseHttpMethodStraetgy(HttpRequestMessage request)
        {
            HttpRequest = request;
        }

        public abstract HttpResponseMessage Invoke();
    }
}