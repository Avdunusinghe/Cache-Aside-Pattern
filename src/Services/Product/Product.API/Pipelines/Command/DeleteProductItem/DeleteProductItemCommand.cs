﻿using Product.API.Exceptions;

namespace Product.API.Pipelines.Command.DeleteProductItem
{
    public record DeleteProductItemCommand(string id) : IRequest<ResultDTO>;

    public class DeleteProductItemCommandHandler(IProductItemRepository _productItemRepository)
        : IRequestHandler<DeleteProductItemCommand, ResultDTO>
    {

        public async Task<ResultDTO> Handle(DeleteProductItemCommand request, CancellationToken cancellationToken)
        {
            var product = await _productItemRepository.GetProductAsync(request.id);

            if (product is null)
            {
                throw new ProductItemNotFoundException(request.id);
            }

            await _productItemRepository.DeleteProductAsync(request.id);

            return ResultDTO.Success("Product has been deleted successfully.", product.Id);
        }
    }

}
