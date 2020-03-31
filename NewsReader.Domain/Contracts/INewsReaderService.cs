using NewsReader.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsReader.Domain.Contracts
{
    public interface INewsReaderService
    {
        Task<List<HackerNewsItem>> GetItems(int skip, int take);
    }
}
