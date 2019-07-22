using Bagdxk.Profile.Service.Api.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bagdxk.Profile.Service.Api.Tests.Cosmos
{
    public class CosmosClientTests : IDisposable
    {
        private const string account = "https://bagdxk-profile-service-db.documents.azure.com:443/";
        private const string key = "h715qPKYFYfQ8631n7q8gam8q074wX4LJALZKbniN65bfofoaxFtQjjyHajJ1OMhhvybQsPuyYA4MExcWo3cdA==";
        private const string dbId = "LayoutDb";
        private const string containerId = "Layouts";

        private CosmosClient client;
        private Container container;

        public CosmosClientTests()
        {
            client = new CosmosClient(account, key);
            container = client.GetContainer(dbId, containerId);
        }

        [Fact]
        public async Task ReadItemAsync_NotExist_Should_NotFound()
        {
            string id = "tianqiac.notexist";
            var ex = await Assert.ThrowsAsync<CosmosException>(() => container.ReadItemAsync<Layout>(id, new PartitionKey(id)));
            Assert.Equal(HttpStatusCode.NotFound, ex.StatusCode);
        }

        [Fact] async Task ReadItemAsync_Exist_Should_Success()
        {
            string id = "tianqiac.exist";
            var actual = await container.ReadItemAsync<Layout>(id, new PartitionKey(id));
            Assert.Equal(id, actual.Resource.id);
        }

        [Fact(Skip = "Manual test")]
        public async Task foo()
        {
            try
            {

                var layout = new Layout
                {
                    id = "tianqiac.exist",
                    Height = 500,
                    Left = 0,
                    Top = 0,
                    Width = 500,
                    WindowState = "Normal"
                };
                var result = await container.CreateItemAsync<Layout>(layout);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debugger.Break();
            }
        }

        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
            }
        }
    }
}
