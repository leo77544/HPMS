using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHelper
{
    public class ApiResult
    {

        #region WebApi
        /// <summary>
        /// 调用API里的方法，获取需要的数据或进行相应的操作
        /// </summary>
        /// <param name="ActionName">API里的方法名及参数</param>
        /// <param name="Verb">请求方式</param>
        /// <param name="Obj">对象参数</param>
        /// <returns>string</returns>
        static public string GetAPIResult(string ActionName, string Verb, object Obj = null)
        {
            string Result = "";
            HttpClient Client = new HttpClient();
            Uri uri = new Uri("http://localhost:60293/api/HPMS/");
            Client.BaseAddress = uri;
            Task<HttpResponseMessage> Task = null;
            switch (Verb)
            {
                case "get":
                    Task = Client.GetAsync(ActionName);
                    break;
                case "post":
                    Task = Client.PostAsJsonAsync(ActionName, Obj);
                    break;
                case "put":
                    Task = Client.PutAsJsonAsync(ActionName, Obj);
                    break;
                case "delete":
                    Task = Client.DeleteAsync(ActionName);
                    break;
            }
            Task.Wait();
            var Response = Task.Result;
            if (Response.IsSuccessStatusCode)
            {
                var Read = Response.Content.ReadAsStringAsync();
                Read.Wait();
                Result = Read.Result;
            }
            return Result;
        }
        #endregion

    }
}
