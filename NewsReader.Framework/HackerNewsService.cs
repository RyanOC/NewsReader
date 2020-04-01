using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsReader.Framework
{
    public class HackerNewsService : INewsReaderService
    {
        public IHackerNewsGateway HackerNewsGateway { get; }

        public HackerNewsService(IHackerNewsGateway newsReaderGateway)
        {
            HackerNewsGateway = newsReaderGateway;
        }

        public async Task<List<HackerNewsItem>> GetItems(int skip, int take)
        {
            var newsArticleList = new List<HackerNewsItem>();
            var topStories = await HackerNewsGateway.GetTopStories();

            //todo: refactor/cleanup using linq
            for (int i = skip; i < take + skip; i++)
            {
                newsArticleList.Add(await HackerNewsGateway.GetItem(int.Parse(topStories[i])));
            }

            return newsArticleList;
        }
    }
}
