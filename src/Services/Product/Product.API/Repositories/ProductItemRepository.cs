using MongoDB.Driver;
using Product.API.Data;
using Product.API.Entities;

namespace Product.API.Repositories
{
    public class ProductItemRepository : IProductItemRepository
    {
        private readonly IProductItemContext _context;

        public ProductItemRepository(IProductItemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<ProductItem>> GetProducts()
        {
            return await _context
                            .ProductItems
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<ProductItem> GetProduct(string id)
        {
            return await _context
                           .ProductItems
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductItem>> GetProductByName(string name)
        {
            FilterDefinition<ProductItem> filter = Builders<ProductItem>.Filter.Eq(p => p.Name, name);

            return await _context
                            .ProductItems
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<ProductItem>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<ProductItem> filter = Builders<ProductItem>.Filter.Eq(p => p.Category, categoryName);

            return await _context
                            .ProductItems
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateProduct(ProductItem product)
        {
            await _context.ProductItems.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProduct(ProductItem product)
        {
            var updateResult = await _context
                                        .ProductItems
                                        .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<ProductItem> filter = Builders<ProductItem>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .ProductItems
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
