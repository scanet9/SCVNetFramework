using System;

namespace CosmosDBRestApi.DataLayer.Infrastructure
{
    public abstract class BaseDocument
    {
        public Guid Id { get; set; }
    }
}
