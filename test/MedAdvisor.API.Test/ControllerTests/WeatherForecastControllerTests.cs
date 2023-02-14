using MedAdvisor.Common.Test;
using Xunit;
using MedAdvisor.Api;
using MedAdvisor.API.Test.Infrastructure;
using FluentAssertions;
using System.Net;
namespace MedAdvisor.API.Test.ControllerTests
{
    public class WeatherForecastControllerTests : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly TestWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;
        private readonly IServiceProvider _serviceProvider;
        public WeatherForecastControllerTests(TestWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _serviceProvider = factory.Services;

        }


            );
            Assert.Equal(HttpStatusCode.OK, httpStatusResponse);
            httpResponseBody.Should().NotBeEmpty().And.HaveCount(5);
        }

    }
}
