using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Cqrs.Rest
{
    /// <summary>
    /// RESTful Service Method POST ���B�z�޿�
    /// </summary>
    /// <remarks>
    /// 1. �����N Command �浹 IProcessCommand (CommandProcessor) �B�z
    /// 2. �ݭn���X�@�� Model �^�ǵ��e��
    /// 3. Header �ݭn�]�w Location HEADER
    /// </remarks>
    public class PostMethodStrategy<T> : BaseHttpMethodStraetgy
    {
        private readonly ICommandRequest<T> _command;

        public PostMethodStrategy(HttpRequestMessage request, ICommandRequest<T> command)
            : base(request)
        {
            _command = command;
        }

        #region Overrides of BaseHttpMethodStraetgy

        public override HttpResponseMessage Invoke()
        {
            var result = CommandProcessor.Execute(_command);

            var respMessage = HttpRequest.CreateResponse(HttpStatusCode.Created, result);
            respMessage.Headers.Location = GetLocation(result);

            return respMessage;
            //throw new NotImplementedException();
        }

        #endregion

        /// <summary>
        /// �γW�w���覡�A���o Command �� Id ���ݩʡA�Ψӷ�@ Location
        /// </summary>
        /// <returns></returns>
        protected virtual Uri GetLocation(T result)
        {
            return new Uri(HttpRequest.RequestUri,
                Url.Route("DefaultApi", new { id = GetIdFromResult(result) }));
        }

        private object GetIdFromResult(T result)
        {
            var idProp = result.GetType()
                .GetProperties()
                .FirstOrDefault(p => p.Name == "Id");

            var idResult = idProp != null ? idProp.GetValue(result) : "";
            Console.WriteLine(idResult);

            return idResult;
        }
    }
}