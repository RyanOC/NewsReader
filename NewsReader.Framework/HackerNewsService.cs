using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;

namespace NewsReader.Framework
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly IConfiguration _configuration;
        private readonly IHackerNewsGateway _hackerNewsGateway;

        public HackerNewsService(IConfiguration configuration, IHackerNewsGateway hackerNewsGateway)
        {
            _configuration = configuration;
            _hackerNewsGateway = hackerNewsGateway;
        }

        public async Task<List<HackerNewsItem>> GetItemsAsync(int pageIndex)
        {
            var newsArticleList = new List<HackerNewsItem>();
            var topStories = await _hackerNewsGateway.GetTopStoriesAsync();
            var totalItems = topStories.Count;
            var pageSize = int.Parse(_configuration["page_count"]);
            var totalPageIndexes = (int)Math.Ceiling(totalItems / (decimal)pageSize) -1;

            if (pageIndex < 0)
            {
                pageIndex = 0;
            }
            else if (pageIndex > totalPageIndexes)
            {
                pageIndex = totalPageIndexes;
            }

            var startIndex = pageIndex * pageSize;

            for (int i = startIndex; i < pageSize + startIndex; i++)
            {
                newsArticleList.Add(await _hackerNewsGateway.GetItemAsync(int.Parse(topStories[i])));
            }

            return newsArticleList;
        }
    }
}
