using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;

namespace XFDemo.Services
{
    public class RestHelper<T>
    {
        private static RestHelper<T> instance;
        public static RestHelper<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RestHelper<T>()
                    {
                        client = new HttpClient( )
                    };

                    instance.client.BaseAddress = new Uri("https://demo6699174.mockable.io");
                    instance.client.DefaultRequestHeaders.Add("Accept", "application/json");
                }
                return instance;
            }

        }

        private HttpClient client;
        public HttpClient Client
        {
            get
            {
                return client;
            }
        }

        public async Task<ResponseObject> GetRequestAsync(string uri)
        {
            HttpResponseMessage response = await Client.GetAsync(uri);

            return await CheckResponse(response);
        }

        public async Task<ResponseObject> PostRequestAsync(object content, string uri)
        {
            HttpResponseMessage response = await Client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(content)));

            return await CheckResponse(response);
        }

        private async Task<ResponseObject> CheckResponse(HttpResponseMessage response)
        { 
            string json = await response.Content.ReadAsStringAsync();

            ResponseObject responseObj = new Services.ResponseObject()
            {
                Content = JsonConvert.DeserializeObject<T>(json),
                IsSuccessResponse = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode
            };           

            return responseObj;      
        }
    }
}
