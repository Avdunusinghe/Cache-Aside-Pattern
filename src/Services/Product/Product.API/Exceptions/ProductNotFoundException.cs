using BuildingBlocks.Exceptions;

namespace Product.API.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(string Id) : base("Product", Id)
    {
    }
}