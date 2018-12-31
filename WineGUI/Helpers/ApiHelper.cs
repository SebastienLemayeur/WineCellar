using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WineGUI.Helpers
{
    class ApiHelper
    {
        public static T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew
                (
                () => JsonConvert.DeserializeObject<T>(response.Result)
                )
                .Result;
            }
        }

        public static async Task<Out> PutCallAPI<Out, In>(string uri, In entity)
        {
            return await CallAPI<Out, In>(uri, entity, HttpMethod.Put);
        }

        public static async Task<Out> PostCallAPI<Out, In>(string uri, In entity)
        {
            return await CallAPI<Out, In>(uri, entity, HttpMethod.Post);
        }

        public static async Task<Out> DelCallAPI<Out>(string uri)
        {
            return await CallAPI<Out, object>(uri, null, HttpMethod.Delete);
        }

        private static async Task<Out> CallAPI<Out, In>(string uri, In entity, HttpMethod method)
        {
            Out result = default(Out);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response;
                if (method == HttpMethod.Post)
                {
                    response = await httpClient.PostAsJsonAsync(uri, entity);
                }
                else if (method == HttpMethod.Put)
                {
                    response = await httpClient.PutAsJsonAsync(uri, entity);
                }
                else
                {
                    response = await httpClient.DeleteAsync(uri);
                }
                result = await response.Content.ReadAsAsync<Out>();
            }
            return result;
        }
    }
}
