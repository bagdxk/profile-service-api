using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bagdxk.Profile.Service.Api.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

namespace Bagdxk.Profile.Service.Api.Services
{
    public class LayoutCosmosDbRepository : ILayoutRepository
    {
        private CosmosClient cosmosClient;
        private Container container;

        public LayoutCosmosDbRepository(string account, string key)
        {
            cosmosClient = new CosmosClient(account, key);
            container = cosmosClient.GetContainer("LayoutDb", "Layouts");
        }

        public async Task<Layout> GetAsync(string id)
        {
            try
            {
                ItemResponse<Layout> response = await this.container.ReadItemAsync<Layout>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Layout> SaveAsync(Layout layout)
        {
            if (layout == null)
            {
                throw new ArgumentNullException(nameof(layout));
            }

            try
            {
                await this.container.ReadItemAsync<Layout>(layout.id, new PartitionKey(layout.id));
            }
            catch (CosmosException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    var createResponse = await this.container.CreateItemAsync<Layout>(layout);
                    return createResponse.Resource;
                }
                else
                {
                    throw;
                }
            }
            return (await this.container.ReplaceItemAsync(layout, layout.id)).Resource;
        }
    }
}
