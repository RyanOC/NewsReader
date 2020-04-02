using NewsReader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsReader.Domain.Contracts
{
    public interface IHackerNewsGateway
    {
        Task<List<string>> GetTopStoriesAsync();
        Task<HackerNewsItem> GetItemAsync(int id);
    }
}
