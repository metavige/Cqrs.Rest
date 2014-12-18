using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Cqrs.Rest
{
    /// <summary>
    /// RESTful Service Method POST 的處理邏輯
    /// </summary>
    /// <remarks>
    /// 1. 直接將 Command 交給 IProcessCommand (CommandProcessor) 處理
    /// 2. 需要產出一個 Model 回傳給前端
    /// 3. Header 需要設定 Location HEADER
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
        /// 用規定的方式，取得 Command 中 Id 的屬性，用來當作 Location
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