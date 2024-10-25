using System.Web.Mvc;

namespace RoutingandURL.Controllers
{
    public class ProductController : Controller
    {
        // Custom route parameter (category and id)
        public ActionResult Details(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.ProductId = id;
            return View();
        }

        // Route for query strings (search term)
        public ActionResult Search(string term)
        {
            ViewBag.SearchTerm = term;
            return View();
        }

        // Example of attribute routing with a route parameter
        [Route("Store/Category/{categoryName}")]
        public ActionResult Category(string categoryName)
        {
            ViewBag.CategoryName = categoryName;
            return View();
        }
    }
}
