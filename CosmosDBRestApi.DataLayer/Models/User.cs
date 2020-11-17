using Newtonsoft.Json;

namespace CosmosDBRestApi.DataLayer.Models
{
    public class User
    {
        public string Guid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surnames { get; set; }
    }
}
