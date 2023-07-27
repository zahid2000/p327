using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Persistance.Context.EfCore;
using ECommerce.Entities.Concrete;

namespace ConsoleApp1
{
    internal class Program
    {
        static  void Main(string[] args)
        {
             Test();
        }

        private static async void Test()
        {
            IProductRepository productRepository = new ProductRepository(new AppDbContext());
            await productRepository.AddAsync(new Product
            {
                Name = "LOTR",
                Price = 200,
                Count = 10,
                IsDeleted = false,
                CategoryId = 1,
                ManufacturerId = 1
            });
            var products = await productRepository.GetAllAsync();
            foreach (var item in products)
            {
                await Console.Out.WriteLineAsync(item.Name);
            }
        }
    }
}