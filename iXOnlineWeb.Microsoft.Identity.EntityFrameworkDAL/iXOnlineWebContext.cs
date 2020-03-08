using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Microsoft.Identity.EntityFrameworkDAL
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class IXOnlineDbContext : IdentityDbContext<ApplicationUser>
    {
        public IXOnlineDbContext()
            : base("iXOnlineIdentity", throwIfV1Schema: false)
        {
        }

        public static IXOnlineDbContext Create()
        {
            return new IXOnlineDbContext();
        }
    }
}
