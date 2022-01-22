using System;
using System.Text.Json.Serialization;
using SCVNetFramework.DataLayer.Sql.Infrastructure;

namespace SqlApiBase.DataLayer.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
    }
}
