using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AsynchronousProgramming.Services
{
    public class ProductService
    {
        // Synchronous method to get products
        public List<string> GetProducts()
        {
            // Simulate a delay (e.g., database call)
            System.Threading.Thread.Sleep(2000); // 2-second delay
            return new List<string> { "Product1", "Product2", "Product3" };
        }

        // Asynchronous method to get products
        public async Task<List<string>> GetProductsAsync()
        {
            // Simulate a delay asynchronously
            await Task.Delay(2000); // 2-second delay
            return new List<string> { "Product1", "Product2", "Product3" };
        }
    }
}