using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;

namespace NewsReader.Infrastructure
{
    public class HackerNewsGateway : IHackerNewsGateway
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HackerNewsGateway(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<string>> GetTopStoriesAsync()
        {
            var client = _httpClientFactory.CreateClient("hackernewsapi");
            var response = await client.GetAsync("topstories.json");
            var listJson = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(listJson);
        }

        public async Task<HackerNewsItem> GetItemAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("hackernewsapi");
            var response = await client.GetAsync($"item/{id}.json");
            var itemJson = await response.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<HackerNewsItem>(itemJson);
        }
    }
}
