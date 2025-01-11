﻿using Mapster;
using MediatR;
using Product.API.DTOs;

namespace Product.API.Pipelines.Query.GetProductItems
{
    public record GetProductItemsQuery : IRequest<List<ProductItemDTO>>;

    public class GetProductItemsQueryHandler(IProductItemRepository productItemRepository)
        : IRequestHandler<GetProductItemsQuery, List<ProductItemDTO>>
    {

        public async Task<List<ProductItemDTO>> Handle(GetProductItemsQuery request, CancellationToken cancellationToken)
        {
            var products = await productItemRepository.GetProducts();

            return products.Adapt<List<ProductItemDTO>>();
        }
    }
}
