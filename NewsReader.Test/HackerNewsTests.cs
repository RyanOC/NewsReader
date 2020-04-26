using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using NewsReader.Web.Controllers;
using NewsReader.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using FluentAssertions;
using System.Collections.Generic;
using NewsReader.Framework;

namespace NewsReader.Test
{
    public class HackerNewsTests
    {
        private readonly Mock<IHackerNewsService> _hackerNewsService;
        private readonly Mock<IHackerNewsGateway> _hackerNewsGateway;
        private readonly Mock<ILogger<NewsReaderController>> _logger;
        private readonly IConfiguration _config;

        public HackerNewsTests()
        {
            _hackerNewsService = new Mock<IHackerNewsService>();
            _hackerNewsGateway = new Mock<IHackerNewsGateway>();
            _logger = new Mock<ILogger<NewsReaderController>>();
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [Fact]
        public void Get_HackerNewsItems_Controller_ShouldReturn_List()
        {
            _hackerNewsService.Setup(svc => svc.GetItemsAsync(0)).ReturnsAsync(Mocks.MockHackerNewsItems.GetHackerNewsItems());

            var controller = new NewsReaderController(_logger.Object, _hackerNewsService.Object);

            controller.Get(0).Result.Should().HaveCount(3);
        }

        [Fact]
        public async void Get_HackerNewsItems_Service_ShouldReturn_List()
        {
            _hackerNewsGateway.Setup(gw => gw.GetTopStoriesAsync()).ReturnsAsync(new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            _hackerNewsGateway.Setup(gw => gw.GetItemAsync(0)).ReturnsAsync(new Domain.Models.HackerNewsItem() { Id = 1 });

            var service = new HackerNewsService(_config, _hackerNewsGateway.Object);
            var results = await service.GetItemsAsync(0);

            results.Count.Should().Be(10);
        }
    }
}
