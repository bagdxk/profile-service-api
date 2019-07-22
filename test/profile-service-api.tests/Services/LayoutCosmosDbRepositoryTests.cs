using Bagdxk.Profile.Service.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bagdxk.Profile.Service.Api.Tests.Services
{
    public class LayoutCosmosDbRepositoryTests
    {
        [Fact]
        public async Task GetAsync_Should_Success()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILayoutRepository>(new LayoutCosmosDbRepository("https://bagdxk-profile-service-db.documents.azure.com:443/"
                , "h715qPKYFYfQ8631n7q8gam8q074wX4LJALZKbniN65bfofoaxFtQjjyHajJ1OMhhvybQsPuyYA4MExcWo3cdA=="));
            using (var provider = services.BuildServiceProvider())
            {
                var repository = provider.GetService<ILayoutRepository>();
                var result = await repository.GetAsync("tianqiac.exist");
            }
        }

        [Fact]
        public async Task SaveAsync_NullLayout_ArgumentException()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ILayoutRepository>(new LayoutCosmosDbRepository("https://bagdxk-profile-service-db.documents.azure.com:443/"
                , "h715qPKYFYfQ8631n7q8gam8q074wX4LJALZKbniN65bfofoaxFtQjjyHajJ1OMhhvybQsPuyYA4MExcWo3cdA=="));
            using (var provider = services.BuildServiceProvider())
            {
                var repository = provider.GetService<ILayoutRepository>();
                var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => repository.SaveAsync(null));
                Assert.Equal("layout", ex.ParamName);
            }
        }
    }
}
