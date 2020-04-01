using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace NewsReader.Infrastructure
{
    public class HackerNewsGateway : IHackerNewsGateway
    {
        public IHttpClientFactory HttpClientFactory { get; }
        public IConfiguration Configuration { get; }

        public HackerNewsGateway(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            HttpClientFactory = httpClientFactory;
            Configuration = configuration;
        }

        public async Task<List<string>> GetTopStories()
        {
            var client = HttpClientFactory.CreateClient("hackernewsapi");
            var response = await client.GetAsync("topstories.json");
            var listJson = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(listJson);
        }

        public async Task<HackerNewsItem> GetItem(int id)
        {
            var client = HttpClientFactory.CreateClient("hackernewsapi");
            var response = await client.GetAsync($"item/{id}.json");
            var itemJson = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<HackerNewsItem>(itemJson);
        }
    }
}
