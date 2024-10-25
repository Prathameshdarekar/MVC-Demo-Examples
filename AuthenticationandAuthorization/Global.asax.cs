using AuthenticationandAuthorization.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AuthenticationandAuthorization
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize roles and default admin user
            CreateRolesAndUsers();
        }

        // This method will set up roles and a default admin user when the application starts
        private void CreateRolesAndUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Check if Admin role exists; if not, create it
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                // Create a default admin user if they do not exist
                if (userManager.FindByName("admin@example.com") == null)
                {
                    var adminUser = new ApplicationUser { UserName = "admin@example.com", Email = "admin@example.com" };
                    string adminPassword = "Admin@123";
                    var userCreationResult = userManager.Create(adminUser, adminPassword);

                    // Assign Admin role to the user if user creation was successful
                    if (userCreationResult.Succeeded)
                    {
                        userManager.AddToRole(adminUser.Id, "Admin");
                    }
                }
            }
        }
    }
}
