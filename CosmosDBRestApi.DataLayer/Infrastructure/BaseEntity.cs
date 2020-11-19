using System;
namespace CosmosDBRestApi.DataLayer.Infrastructure
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
