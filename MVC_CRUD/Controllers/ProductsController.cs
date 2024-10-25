// Controllers/ProductsController.cs
using MVC_CRUD.Data;
using MVC_CRUD.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YourNamespace.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            // Fetch and return all products
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View(); // Return the Create view
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public async Task<ActionResult> Create(Products product)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                _context.Products.Add(product); // Add the product to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction("Index"); // Redirect to the Index action
            }
            return View(product); // Return the view with the product data
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) // Check if id is null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Return BadRequest
            }

            var product = await _context.Products.FindAsync(id); // Find the product by id
            if (product == null) // Check if the product exists
            {
                return HttpNotFound(); // Return NotFound if the product is not found
            }
            return View(product); // Return the Edit view with the product data
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Products product)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                _context.Entry(product).State = EntityState.Modified; // Mark the product as modified
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction("Index"); // Redirect to the Index action
            }
            return View(product); // Return the view with the product data
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) // Check if id is null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Return BadRequest
            }

            var product = await _context.Products.FindAsync(id); // Find the product by id
            if (product == null) // Check if the product exists
            {
                return HttpNotFound(); // Return NotFound if the product is not found
            }
            return View(product); // Return the Delete view with the product data
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id); // Find the product by id
            _context.Products.Remove(product); // Remove the product from the context
            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction("Index"); // Redirect to the Index action
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose(); // Dispose the context
            }
            base.Dispose(disposing); // Call the base Dispose method
        }
    }
}
