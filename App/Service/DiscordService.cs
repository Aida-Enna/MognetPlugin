using MognetPlugin.Http;
using MognetPlugin.Model;
using MognetPlugin.Util;
using System.Net.Http;
using System.Threading.Tasks;

namespace MognetPlugin.Service
{
    class DiscordService
    {
        PluginHttpClient Client;

        public DiscordService()
        {
            Client = new PluginHttpClient();
        }

        public async Task<DiscordChannel> CheckToken(string token)
        {
            HttpResponseMessage Result = Client.CheckToken(token);
            if (Result.IsSuccessStatusCode)
            {
                try
                {
                    return PluginUtil.FromJson<DiscordChannel>(await Result.Content.ReadAsStringAsync());
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public bool PostDiscord(string json, string token)
        {
            HttpResponseMessage Result = Client.PostDiscord(json, token);
            if (Result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
