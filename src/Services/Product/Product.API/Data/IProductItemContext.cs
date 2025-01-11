using MongoDB.Driver;
using Product.API.Entities;

namespace Product.API.Data
{
    public interface IProductItemContext
    {
        IMongoCollection<ProductItem> ProductItems { get; }
    }
}
