using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CosmosDBRestApi.DataLayer.Infrastructure
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
