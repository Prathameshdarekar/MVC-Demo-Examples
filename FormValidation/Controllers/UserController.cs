// Controllers/UserController.cs
using FormValidation.Models;
using System.Web.Mvc;

namespace FormValidation.Controllers
{
    public class UserController : Controller
    {
        // Display the registration form
        public ActionResult Register()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegistrationModel model)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Process the registration data (e.g., save to database)
                TempData["SuccessMessage"] = "Registration successful!";
                return RedirectToAction("Success");
            }

            // If validation fails, redisplay the form with error messages
            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
