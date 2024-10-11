using Marten.Schema;
using System.Net.WebSockets;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone",
                Description ="This is iphone 14 pro",
                ImageFile = "product1.png",
                Price = 12000,
                Category = new List<string>{"SmartPhone", "HP"}
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung A52",
                Description ="This is Samsung A52",
                ImageFile = "product2.png",
                Price=1500,
                Category = new List<string>{"SmartPhone", "HP", "HP Samsung", "Samsung"}
            },
               new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Oppo Flip A22",
                Description ="This is Oppo Flip A22",
                ImageFile = "product3.png",
                Price=3000,
                Category = new List<string>{"SmartPhone", "HP", "HP Oppo"}
            }
        };
    }
}
