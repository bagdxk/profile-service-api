using Bagdxk.Profile.Service.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Bagdxk.Profile.Service.Api.Tests.Services
{
    public class ValuesServiceTests
    {
        [Fact]
        public void Get_Should_Ok()
        {
            var services = new ServiceCollection();
            services.AddTransient<IValuesService, ValuesService>();
            var provider = services.BuildServiceProvider();
            var service = provider.GetService<IValuesService>();

            var result = service.Get();
            Assert.Equal(new string[] { "value1", "value2" }, result);
        }
    }
}
