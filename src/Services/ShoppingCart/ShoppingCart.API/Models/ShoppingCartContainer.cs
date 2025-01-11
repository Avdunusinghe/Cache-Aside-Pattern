namespace ShoppingCart.API.Models
{
    public class ShoppingCartContainer
    {
        //Required for Mapping Profile in Mapster
        public ShoppingCartContainer()
        {
        }

        public ShoppingCartContainer(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);




    }
}
