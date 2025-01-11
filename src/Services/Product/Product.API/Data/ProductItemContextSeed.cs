using MongoDB.Driver;

namespace Product.API.Data
{
    public class ProductItemContextSeed
    {
        public static void SeedData(IMongoCollection<ProductItem> products)
        {
            try
            {
                bool existProduct = products.Find(p => true).Any();

                if (!existProduct)
                {
                    products.InsertManyAsync(GetPreconfiguredProductItems());
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private static IEnumerable<ProductItem> GetPreconfiguredProductItems()
        {
            return new List<ProductItem>()
            {
                new ProductItem()
                {

                    Name = "Dell XPS 15",
                    Summary = "A high-performance laptop with premium build quality and powerful specs.",
                    Description = "The Dell XPS 15 offers a stunning 15.6-inch 4K OLED display, a sleek aluminum chassis, and exceptional performance for both work and play. With the latest Intel Core processors, NVIDIA GeForce RTX graphics, and up to 32GB of RAM, it's a powerhouse for professionals and creators. Ideal for multitasking, video editing, and gaming.",
                    ImageFile = "laptop-dell-xps-15.png",
                    Price = 1899.99M,
                    Category = "Laptop"
                },
                new ProductItem()
                {

                    Name = "Dell XPS 15",
                    Summary = "A high-performance laptop with premium build quality and powerful specs.",
                    Description = "The Dell XPS 15 offers a stunning 15.6-inch 4K OLED display, a sleek aluminum chassis, and exceptional performance for both work and play. With the latest Intel Core processors, NVIDIA GeForce RTX graphics, and up to 32GB of RAM, it's a powerhouse for professionals and creators.",
                    ImageFile = "laptop-dell-xps-15.png",
                    Price = 1899.99M,
                    Category = "Laptop"
                },
                new ProductItem()
                {

                    Name = "MacBook Pro 16",
                    Summary = "Apple's flagship laptop designed for power users and creatives.",
                    Description = "The MacBook Pro 16 features a Liquid Retina XDR display, Apple's M2 Max chip, and exceptional battery life. Perfect for video editing, software development, and resource-heavy applications, it combines performance with an elegant design.",
                    ImageFile = "laptop-macbook-pro-16.png",
                    Price = 2499.00M,
                    Category = "Laptop"
                },
                new ProductItem()
                {

                    Name = "HP Spectre x360",
                    Summary = "A versatile 2-in-1 laptop with premium features and build quality.",
                    Description = "The HP Spectre x360 comes with a 13.5-inch OLED touchscreen, Intel Evo platform, and a 360-degree hinge, allowing seamless transition between laptop and tablet modes. It’s lightweight and offers long battery life, making it ideal for productivity on the go.",
                    ImageFile = "laptop-hp-spectre-x360.png",
                    Price = 1399.99M,
                    Category = "Laptop"
                },
                new ProductItem()
                {

                    Name = "Lenovo ThinkPad X1 Carbon",
                    Summary = "A durable and lightweight business laptop with top-tier performance.",
                    Description = "The Lenovo ThinkPad X1 Carbon is engineered for professionals, offering a 14-inch 2K display, advanced security features, and an ergonomic keyboard. It's powered by Intel Core i7 processors and provides excellent connectivity options.",
                    ImageFile = "laptop-lenovo-thinkpad-x1.png",
                    Price = 1599.99M,
                    Category = "Laptop"
                },
                new ProductItem()
                {

                    Name = "ASUS ROG Zephyrus G14",
                    Summary = "A compact gaming laptop with impressive performance and portability.",
                    Description = "The ASUS ROG Zephyrus G14 packs AMD Ryzen 9 processors and NVIDIA GeForce RTX 4060 graphics into a lightweight design. Its 14-inch QHD display, customizable RGB keyboard, and exceptional cooling make it perfect for gamers and creators.",
                    ImageFile = "laptop-asus-rog-zephyrus-g14.png",
                    Price = 1799.99M,
                    Category = "Laptop"
                },
            };
        }
    }
}
