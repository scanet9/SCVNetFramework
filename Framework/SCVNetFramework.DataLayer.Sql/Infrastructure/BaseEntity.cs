using System;
namespace SCVNetFramework.DataLayer.Sql.Infrastructure
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
