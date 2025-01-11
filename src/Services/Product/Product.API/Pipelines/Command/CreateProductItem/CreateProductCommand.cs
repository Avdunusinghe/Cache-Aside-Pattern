namespace Product.API.Pipelines.Command.CreateProductItem
{
    public record CreateProductCommand(ProductItemDTO ProductItemDTO) : IRequest<ResultDTO>;

    public class CreateProductCommandHandler(IProductItemRepository productItemRepository)
        : IRequestHandler<CreateProductCommand, ResultDTO>
    {

        public async Task<ResultDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.ProductItemDTO.Adapt<ProductItem>();
            await productItemRepository.CreateProductAsync(product);

            return ResultDTO.Success("Product has been added successfully.", product.Id);
        }
    }


}
