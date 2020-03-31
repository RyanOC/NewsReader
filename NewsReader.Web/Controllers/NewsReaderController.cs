using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NewsReader.Domain.Contracts;
using NewsReader.Domain.Models;

namespace NewsReader.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsReaderController : ControllerBase
    {
        private readonly ILogger<NewsReaderController> _logger;
        public IConfiguration _configuration { get; }
        public INewsReaderService _newsReaderService { get; }

        public NewsReaderController(ILogger<NewsReaderController> logger, IConfiguration configuration, INewsReaderService newsReaderService)
        {
            _logger = logger;
            _configuration = configuration;
            _newsReaderService = newsReaderService;
        }

        [HttpGet]
        public async Task<IEnumerable<HackerNewsItem>> Get()
        {
            return await _newsReaderService.GetItems(0, 10);
        }
    }
}