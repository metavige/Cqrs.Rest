/*
 * 透過 CQRS Pattern 的方式，不是把邏輯寫在 ApiController
 * 而且也不是透過繼承方式來作 CRUD 的邏輯繼承，因為如果傳遞參數不一致，就不容易作到繼承
 *
 * 這個 Extension 只是協助 ApiController 支援 RESTful 相關的規則
 * 比如說 POST 新增需要把網址放在 HEADER 的 Location 屬性上
 *
 */

using System.Net.Http;
using System.Web.Http;

namespace Cqrs.Rest.Api
{
    /// <summary>
    /// CRUD ApiController Extension
    /// </summary>
    /// <remarks>
    ///
    ///
    /// </remarks>
    public static class RestApiSupportExtension
    {
        public static void Delegate(this ApiController controller, HttpMethod method)
        {
        }

        public static T Delegate<T>(this ApiController controller, HttpMethod method)
        {
            return default (T);
        }
    }
}
