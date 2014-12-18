using System.Net.Http;

namespace Cqrs.Rest
{
    public interface IRestfulStrategy
    {
        HttpResponseMessage Invoke();

        HttpRequestMessage HttpRequest { get; }
    }
}
