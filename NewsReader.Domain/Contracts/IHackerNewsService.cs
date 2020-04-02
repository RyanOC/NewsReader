using NewsReader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsReader.Domain.Contracts
{
    public interface IHackerNewsService
    {
        Task<List<HackerNewsItem>> GetItemsAsync(int skip, int take);
    }
}
