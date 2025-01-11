namespace ShoppingCart.API.Pipelines.Command.DeleteShoppingCart
{
    public record DeleteShoppingCartCommand(string UserName) : IRequest<ResultDTO>;

    public class DeleteShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        : IRequestHandler<DeleteShoppingCartCommand, ResultDTO>
    {
        public async Task<ResultDTO> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await shoppingCartRepository.DeleteShoppingCart(request.UserName, cancellationToken);

            return ResultDTO.Success("Shopping Cart Has Been Deleted Successfully");
        }
    }
}
