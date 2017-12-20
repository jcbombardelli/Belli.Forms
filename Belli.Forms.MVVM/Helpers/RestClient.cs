using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Belli.Forms.MVVM.Helpers
{

    public enum HTTPMethod { GET, POST, PUT, DELETE }

    public class RestClient
    {

        private HttpClient httpClient;
        private string uri;

        private const long MaxResponseContent = 256000;


        private RestClient()
        {
            httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public RestClient(string uri) : this()
        {
            this.uri = uri;
        }

        public RestClient(string uri, string user, string pass) : this(uri)
        {
            var authData = string.Format("{0}:{1}", user, pass);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public Task<HttpResponseMessage> Request(string uri, HTTPMethod httpMethod)
        {
            return Request(uri, httpMethod, null);
        }

        public async Task<HttpResponseMessage> Request(string uri, HTTPMethod httpMethod, object entity)
        {

            HttpResponseMessage response = null;

            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            try
            {
                switch (httpMethod)
                {
                    case HTTPMethod.GET:
                        response = httpClient.GetAsync(uri).Result;
                        break;
                    case HTTPMethod.POST:
                        response = await httpClient.PostAsync(uri, content);
                        break;
                    case HTTPMethod.PUT:
                        response = await httpClient.PutAsync(uri, content);
                        break;
                    case HTTPMethod.DELETE:
                        response = await httpClient.DeleteAsync(uri);
                        break;
                    default:
                        return new HttpResponseMessage();
                }
                return response;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}
