using Bagdxk.Profile.Service.Api;
using Bagdxk.Profile.Service.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bagdxk.Profile.Service.Api.Tests.Controllers
{
    public class ValuesControllerTests
    {
        [Fact]
        public void Get_Should_Ok()
        {
            var services = new ServiceCollection();
            var valuesService = new Mock<IValuesService>();
            //valuesService.Setup(x => x.Get());
                //.Returns(new string[] { "value1", "value2" });
            services.AddSingleton<IValuesService>(valuesService.Object);
            services.AddTransient<ValuesController>();
            var provider = services.BuildServiceProvider();
            var controller = provider.GetService<ValuesController>();

            var result = controller.Get();
            valuesService.Verify(x => x.Get(), Times.Once());

        }
    }
}
