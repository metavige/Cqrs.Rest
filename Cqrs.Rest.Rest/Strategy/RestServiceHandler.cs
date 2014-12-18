using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Practices.ServiceLocation;

namespace Cqrs.Rest
{
    public class RestServiceHandler
    {
        static readonly IDictionary<HttpMethod, Type> Strategies
            = new Dictionary<HttpMethod, Type>
            {
                //{ HttpMethod.Get, typeof(GetMethodStrategy) },
                { HttpMethod.Post, typeof(PostMethodStrategy<>) },
                { HttpMethod.Put, typeof(PutMethodStrategy<>) },
                { HttpMethod.Delete, typeof(DeleteMethodStrategy) }
            };

        private readonly IUnityContainer _container;

        public RestServiceHandler(IUnityContainer container)
        {
            _container = container;
        }

        public HttpResponseMessage Handle(HttpRequestMessage request, ICommandRequest command)
        {
            

            var strategy = _container.Resolve(Strategies[request.Method], 
                new ParameterOverride("command", command),
                new ParameterOverride("request", request)) as IRestfulStrategy;

            return Handle(strategy);
        }

        public HttpResponseMessage Handle(IRestfulStrategy strategy)
        {
            return strategy.Invoke();
        }

        public HttpResponseMessage Handle<T>(HttpRequestMessage request, ICommandRequest<T> command)
        {
            var strategy = _container.Resolve(Strategies[request.Method].MakeGenericType(typeof(T)),
                new ParameterOverride("command", command),
                new ParameterOverride("request", request)) as IRestfulStrategy;
            //strategy.Comamnd = command;

            return Handle(strategy);
        }

        public HttpResponseMessage Handle<T>(IRestfulStrategy strategy)
        {
            return strategy.Invoke();
        }
    }
}