using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<string> GetProducts()
        {
            return new List<string> { "Product1", "Product2", "Product3" };
        }
    }
}