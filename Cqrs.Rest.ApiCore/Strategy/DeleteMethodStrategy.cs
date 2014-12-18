using System.Net;
using System.Net.Http;

namespace Cqrs.Rest
{
    public class DeleteMethodStrategy : BaseHttpMethodStraetgy
    {
        private readonly ICommandRequest _command;

        public DeleteMethodStrategy(HttpRequestMessage request, ICommandRequest command)
            : base(request)
        {
            _command = command;
        }

        #region Overrides of BaseHttpMethodStraetgy

        public override HttpResponseMessage Invoke()
        {
            CommandProcessor.Execute(_command);

            return HttpRequest.CreateResponse(HttpStatusCode.NoContent);
        }

        #endregion
    }
}