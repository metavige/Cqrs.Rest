using System.Net;
using System.Net.Http;

namespace Cqrs.Rest
{
    public class PutMethodStrategy<T> : BaseHttpMethodStraetgy
    {

        private readonly ICommandRequest<T> _command;

        public PutMethodStrategy(HttpRequestMessage request, ICommandRequest<T> command)
            : base(request)
        {
            _command = command;
        }

        #region Overrides of BaseHttpMethodStraetgy

        public override HttpResponseMessage Invoke()
        {
            var result = CommandProcessor.Execute(_command);

            return HttpRequest.CreateResponse(HttpStatusCode.OK, result);
        }

        #endregion
    }
}