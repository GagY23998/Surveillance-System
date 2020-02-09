using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace Desktop
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Token { get; set; }
        private string _route;

        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object searchObject)
        {
            var url = $"{Properties.Settings.Default.WEBApi}/{_route}";
            if (searchObject != null)
            {
                url += "?";
                url += await searchObject.ToQueryString();
            }
            try
            {
                var result = await url.WithHeader("Authorization",Token)/*.WithBasicAuth(Username,Password)*/.GetJsonAsync<T>();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<T> Get<T>()
        {
            var result = $"{Properties.Settings.Default.WEBApi}/{_route}";
            return await result.WithHeader("Authorization",Token).GetJsonAsync<T>();
        }
        public async Task<T> GetById<T>(object id)
        {
            var result = $"{Properties.Settings.Default.WEBApi}/{_route}/{id}";
            return await result.WithHeader("Authorization",Token).GetJsonAsync<T>();

        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.WEBApi}/{_route}/";
            if(_route != "token")
            {
                return await url.WithHeader("Authorization",Token).PostJsonAsync(request).ReceiveJson<T>();
            }
            return await url.PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{Properties.Settings.Default.WEBApi}/{_route}/{id}";
            return await url.AllowAnyHttpStatus().WithHeader("Authorization",Token).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Delete<T>(object id)
        {
            var url = $"{Properties.Settings.Default.WEBApi}/{_route}/{id}";

            return await url.WithHeader("Authorization",Token).SendJsonAsync(HttpMethod.Delete, id).ReceiveJson<T>();
        }
    }
}
