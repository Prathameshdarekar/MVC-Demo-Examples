// Models/IdentityModels/ApplicationDbContext.cs
using AuthenticationandAuthorization.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AuthenticationandAuthorization.Models.IdentityModels
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection") // Use your connection string name
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
