using MongoDB.Driver;
using Product.API.Entities;

namespace Product.API.Data
{
    public class ProductItemContext : IProductItemContext
    {
        public ProductItemContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            ProductItems = database.GetCollection<ProductItem>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<ProductItem> ProductItems { get; }
    }

}
