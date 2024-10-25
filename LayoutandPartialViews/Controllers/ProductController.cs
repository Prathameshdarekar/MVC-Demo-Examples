using LayoutandPartialViews.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace YourNamespace.Controllers
{
    public class ProductController : Controller
    {
        // Mock list of products (replace with database context if using Entity Framework)
        private static readonly List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99M },
            new Product { Id = 2, Name = "Smartphone", Price = 599.99M },
            new Product { Id = 3, Name = "Headphones", Price = 199.99M },
            new Product { Id = 4, Name = "Smartwatch", Price = 249.99M }
        };

        // GET: Product/List
        public ActionResult List()
        {
            // Pass the list of products to the view
            return View(products);
        }

        // GET: Product/Details/1
        public ActionResult Details(int id)
        {
            // Find the product by its ID
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            // Pass the single product to the view
            return View(product);
        }
    }
}
