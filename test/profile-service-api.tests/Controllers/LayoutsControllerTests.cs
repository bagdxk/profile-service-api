using Bagdxk.Profile.Service.Api.Controllers;
using Bagdxk.Profile.Service.Api.Models;
using Bagdxk.Profile.Service.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bagdxk.Profile.Service.Api.Tests.Controllers
{
    public class LayoutsControllerTests
    {
        [Fact]
        public async Task GetAsync_Should_Ok()
        {
            var services = new ServiceCollection();
            var layoutRepositoryMock = new Mock<ILayoutRepository>();
            services.AddSingleton<ILayoutRepository>(layoutRepositoryMock.Object);
            services.AddTransient<LayoutsController>();
            var provider = services.BuildServiceProvider();
            var controller = provider.GetService<LayoutsController>();

            var result = await controller.GetAsync("tianqiac.kudpwetr00033");
            layoutRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task SaveAsync_Should_Ok()
        {
            var services = new ServiceCollection();
            var layoutRepositoryMock = new Mock<ILayoutRepository>();
            services.AddSingleton<ILayoutRepository>(layoutRepositoryMock.Object);
            services.AddTransient<LayoutsController>();
            var provider = services.BuildServiceProvider();
            var controller = provider.GetService<LayoutsController>();

            var layout = Mock.Of<Layout>();
            layout.id = "tianqiac.kudpwetr00033";
            var result = await controller.SaveAsync(layout.id, layout);
            layoutRepositoryMock.Verify(x => x.SaveAsync(It.IsAny<Layout>()), Times.Once());

        }
    }
}
