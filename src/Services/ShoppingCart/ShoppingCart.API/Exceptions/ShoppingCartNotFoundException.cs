

namespace ShoppingCart.API.Exceptions
{
    public class ShoppingCartNotFoundException : NotFoundException
    {
        public ShoppingCartNotFoundException(string userName) : base("ShoppingCart", userName)
        {

        }
    }

}
