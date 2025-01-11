using BuildingBlocks.Exceptions;

namespace Product.API.Exceptions;

public class ProductItemNotFoundException : NotFoundException
{
    public ProductItemNotFoundException(string Id) : base("Product", Id)
    {
    }
}