// Models/IdentityModels/ApplicationUser.cs
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationandAuthorization.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        // Method to generate the identity for the user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note that the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here, if needed
            return userIdentity;
        }
    }
}
