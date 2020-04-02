using NewsReader.Domain.Models;
using System.Collections.Generic;

namespace NewsReader.Test.Mocks
{
    public static class MockHackerNewsItems
    {
        public static List<HackerNewsItem> GetHackerNewsItems()
        {
            return new List<HackerNewsItem>() { 
                new HackerNewsItem() { Id = 1, Title = "test item 1" },
                new HackerNewsItem() { Id = 2, Title = "test item 2" },
                new HackerNewsItem() { Id = 3, Title = "test item 3" },
            };
        }
    }
}
