namespace Product.API.Repositories
{
    public interface IProductItemRepository
    {
        Task<IEnumerable<ProductItem>> GetProductsAsync();
        Task<ProductItem> GetProductAsync(string id);
        Task<IEnumerable<ProductItem>> GetProductByNameAsync(string name);
        Task<IEnumerable<ProductItem>> GetProductByCategoryAsync(string categoryName);

        Task CreateProductAsync(ProductItem product);
        Task<bool> UpdateProductAsync(ProductItem product);
        Task<bool> DeleteProductAsync(string id);
    }
}
