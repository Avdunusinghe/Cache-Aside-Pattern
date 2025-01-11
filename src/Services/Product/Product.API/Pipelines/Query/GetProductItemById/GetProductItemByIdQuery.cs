using Product.API.Exceptions;

namespace Product.API.Pipelines.Query.GetProductItemById
{
    public record GetProductItemByIdQuery(string Id) : IRequest<ProductItemDTO>;

    public class GetProductItemByIdQueryHandler(IProductItemRepository productItemRepository)
        : IRequestHandler<GetProductItemByIdQuery, ProductItemDTO>
    {

        public async Task<ProductItemDTO> Handle(GetProductItemByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productItemRepository.GetProduct(request.Id);

            if (product is null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            return product.Adapt<ProductItemDTO>();
        }
    }

}
