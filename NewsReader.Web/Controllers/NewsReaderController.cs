using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;

namespace NewsReader.Web.Controllers
{
    [ApiController]
    public class NewsReaderController : ControllerBase
    {
        private readonly ILogger<NewsReaderController> _logger;
        public IConfiguration _configuration { get; }
        public IHackerNewsService _hackerNewsService { get; }

        public NewsReaderController(ILogger<NewsReaderController> logger, IConfiguration configuration, IHackerNewsService newsReaderService)
        {
            _logger = logger;
            _configuration = configuration;
            _hackerNewsService = newsReaderService;
        }

        [Route("api/newsreader/{pageIndex}")]
        [HttpGet]
        public async Task<IEnumerable<HackerNewsItem>> Get(int pageIndex)
        {
            var take = int.Parse(_configuration["page_count"]);

            return await _hackerNewsService.GetItemsAsync(pageIndex * take, take);
        }
    }
}