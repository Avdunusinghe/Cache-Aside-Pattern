namespace Product.API.Pipelines.Command.UpdateProductItem
{
    public record UpdateProductItemCommand(ProductItemDTO ProductItemDTO) : IRequest<ResultDTO>;

    public class UpdateProductItemCommandHandler(IProductItemRepository productItemRepository)
        : IRequestHandler<UpdateProductItemCommand, ResultDTO>
    {

        public async Task<ResultDTO> Handle(UpdateProductItemCommand request, CancellationToken cancellationToken)
        {
            var product = request.ProductItemDTO.Adapt<ProductItem>();

            await productItemRepository.UpdateProduct(product);

            return ResultDTO.Success("Product has been updated successfully.", product.Id);
        }
    }
}
