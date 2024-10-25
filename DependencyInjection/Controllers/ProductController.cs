using DependencyInjection.Services;
using System.Web.Mvc;

namespace DependencyInjection.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        // Dependency is injected via the constructor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
    }
}
