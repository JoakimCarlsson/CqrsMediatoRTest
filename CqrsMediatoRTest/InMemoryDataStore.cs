using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsMediatoRTest.Models;

namespace CqrsMediatoRTest
{
    public class InMemoryDataStore
    {
        private static List<Models.Product> _products;
        public InMemoryDataStore()
        {
            _products = new List<Models.Product>
            {
                new() { Id = 1, Name = "Test Product 1" },
                new() { Id = 2, Name = "Test Product 2" },
                new() { Id = 3, Name = "Test Product 3" }
            };
        }
        public async Task AddProduct(Models.Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Models.Product>> GetAllProducts() => await Task.FromResult(_products);
        public async Task<Models.Product> GetProductById(int id) => await Task.FromResult(_products.First(i => i.Id == id));

        public async Task EventOccured(Models.Product product, string evt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
