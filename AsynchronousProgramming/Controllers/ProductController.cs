using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AsynchronousProgramming.Services;

namespace AsynchronousProgramming.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService(); // Ideally, inject this service via DI
        }

        // Synchronous action method
        public ActionResult Index()
        {
            // Call the synchronous GetProducts method
            List<string> products = _productService.GetProducts();

            // Return view with the product list
            return View(products);
        }

        // Asynchronous action method
        public async Task<ActionResult> IndexAsync()
        {
            // Call the asynchronous GetProductsAsync method
            List<string> products = await _productService.GetProductsAsync();

            // Return view with the product list
            return View("Index", products);
        }
    }
}
