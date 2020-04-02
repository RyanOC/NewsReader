using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsReader.Framework
{
    public class HackerNewsService : IHackerNewsService
    {
        public IHackerNewsGateway HackerNewsGateway { get; }

        public HackerNewsService(IHackerNewsGateway newsReaderGateway)
        {
            HackerNewsGateway = newsReaderGateway;
        }

        public async Task<List<HackerNewsItem>> GetItemsAsync(int skip, int take)
        {
            var newsArticleList = new List<HackerNewsItem>();
            var topStories = await HackerNewsGateway.GetTopStoriesAsync();

            //todo: refactor/cleanup using linq
            for (int i = skip; i < take + skip; i++)
            {
                newsArticleList.Add(await HackerNewsGateway.GetItemAsync(int.Parse(topStories[i])));
            }

            return newsArticleList;
        }
    }
}
