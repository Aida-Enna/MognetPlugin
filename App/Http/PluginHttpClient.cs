using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MognetPlugin.Http
{
    internal class PluginHttpClient
    {
        private string BaseURL = "https://mognet.herokuapp.com";
        private HttpClient Client;

        public PluginHttpClient()
        {
            Client = new HttpClient();
        }

        public HttpResponseMessage PostDiscord(string json, string token)
        {
            StringContent Body = new StringContent(json, Encoding.UTF8, "application/json");
            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            return Client.PostAsync(new Uri(BaseURL + "/discord"), Body).Result;
        }

        public HttpResponseMessage CheckToken(string token)
        {
            return Client.GetAsync(new Uri(BaseURL + "/check-token/" + token)).Result;
        }
    }
}