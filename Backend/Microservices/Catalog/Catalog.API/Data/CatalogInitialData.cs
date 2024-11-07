using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            var product = await session.Query<Product>().AnyAsync();
            if (product) return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync(cancellation);
        }

        public static IEnumerable<Product> GetPreconfiguredProducts()
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Wireless Mouse",
                    Category = new List<string> { "Electronics", "Accessories" },
                    Description = "A comfortable and responsive wireless mouse.",
                    ImageFile = "wireless_mouse.jpg",
                    Price = 25.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Mechanical Keyboard",
                    Category = new List<string> { "Electronics", "Accessories" },
                    Description = "A durable mechanical keyboard with RGB lighting.",
                    ImageFile = "mechanical_keyboard.jpg",
                    Price = 59.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Bluetooth Speaker",
                    Category = new List<string> { "Electronics", "Audio" },
                    Description = "Portable Bluetooth speaker with high-quality sound.",
                    ImageFile = "bluetooth_speaker.jpg",
                    Price = 45.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "4K Monitor",
                    Category = new List<string> { "Electronics", "Display" },
                    Description = "A high-resolution 4K monitor for crisp visuals.",
                    ImageFile = "4k_monitor.jpg",
                    Price = 299.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Gaming Headset",
                    Category = new List<string> { "Electronics", "Audio", "Gaming" },
                    Description = "Over-ear gaming headset with surround sound.",
                    ImageFile = "gaming_headset.jpg",
                    Price = 89.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone Stand",
                    Category = new List<string> { "Accessories", "Mobile" },
                    Description = "Adjustable smartphone stand for hands-free use.",
                    ImageFile = "smartphone_stand.jpg",
                    Price = 15.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "USB-C Charger",
                    Category = new List<string> { "Electronics", "Mobile", "Accessories" },
                    Description = "Fast-charging USB-C charger with multiple ports.",
                    ImageFile = "usb_c_charger.jpg",
                    Price = 29.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Portable SSD",
                    Category = new List<string> { "Electronics", "Storage" },
                    Description = "Fast, portable SSD with 1TB capacity.",
                    ImageFile = "portable_ssd.jpg",
                    Price = 129.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smart Watch",
                    Category = new List<string> { "Wearable", "Electronics" },
                    Description = "Smart watch with fitness tracking and notifications.",
                    ImageFile = "smart_watch.jpg",
                    Price = 199.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop Stand",
                    Category = new List<string> { "Accessories", "Office" },
                    Description = "Adjustable laptop stand for ergonomic setup.",
                    ImageFile = "laptop_stand.jpg",
                    Price = 49.99m
                }
            };
            return products;
        }
    }
}
