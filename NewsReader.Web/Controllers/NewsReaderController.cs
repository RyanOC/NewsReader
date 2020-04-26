using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;

namespace NewsReader.Web.Controllers
{
    [ApiController]
    public class NewsReaderController : ControllerBase
    {
        private readonly ILogger<NewsReaderController> _logger;
        private readonly IHackerNewsService _hackerNewsService;

        public NewsReaderController(ILogger<NewsReaderController> logger, IHackerNewsService newsReaderService)
        {
            _logger = logger;
            _hackerNewsService = newsReaderService;
        }

        [Route("api/newsreader/{pageIndex}")]
        [HttpGet]
        public async Task<IEnumerable<HackerNewsItem>> Get(int pageIndex)
        {
            return await _hackerNewsService.GetItemsAsync(pageIndex);
        }
    }
}