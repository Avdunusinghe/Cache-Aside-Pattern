namespace Product.API.Pipelines.Query.GetProductByCategory
{
    public record GetProductByCategoryQuery(string category) : IRequest<List<ProductItemDTO>>;

    public class GetProductByCategoryQueryHandler(IProductItemRepository productItemRepository)
        : IRequestHandler<GetProductByCategoryQuery, List<ProductItemDTO>>
    {
        public async Task<List<ProductItemDTO>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await productItemRepository.GetProductByCategoryAsync(request.category);

            return products.Adapt<List<ProductItemDTO>>();
        }
    }


}
