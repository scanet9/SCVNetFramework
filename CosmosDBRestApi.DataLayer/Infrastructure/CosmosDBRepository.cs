//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;
//using CosmosDBRestApi.DataLayer.Infrastructure.Interfaces;
//using Microsoft.Azure.Cosmos;

//namespace CosmosDBRestApi.DataLayer.Infrastructure
//{
//    public class CosmosDBRepository<T> : ICosmosDBRepository<T>
//    {
//        private readonly CosmosDBRestApiContext _context;

//        public CosmosDBRepository(CosmosDBRestApiContext context)
//        {
//            _context = context;
//        }

//        public async Task AddItemAsync(T item)
//        {
//            //Type myType = item.GetType();
//            //PropertyInfo propertyInfo = myType.GetProperty("Guid");
//            //await this._container.CreateItemAsync<T>(item, new PartitionKey(propertyInfo.GetValue(item).ToString()));

//            item.Id = Guid.NewGuid();
//            var response = await ctx.Profiles.AddAsync(entity);
//            await ctx.SaveChangesAsync();
//            return response.Entity;
//        }

//        public async Task UpdateItemAsync(string guid, T item)
//        {
//            await this._container.UpsertItemAsync<T>(item, new PartitionKey(guid));
//        }

//        public async Task DeleteItemAsync(string guid)
//        {
//            await this._container.DeleteItemAsync<T>(guid, new PartitionKey(guid));
//        }

//        public async Task<T> GetItemAsync(string guid)
//        {
//            try
//            {
//                ItemResponse<T> response = await this._container.ReadItemAsync<T>(guid, new PartitionKey(guid));
//                return response.Resource;
//            }
//            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
//            {
//                return default(T);
//            }
//        }

//        //public async Task<IEnumerable<T>> GetItemsAsync(string queryString)
//        //{
//        //    var query = this._container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
//        //    List<T> results = new List<T>();
//        //    while (query.HasMoreResults)
//        //    {
//        //        var response = await query.ReadNextAsync();

//        //        results.AddRange(response.ToList());
//        //    }

//        //    return results;
//        //}
//    }
//}
