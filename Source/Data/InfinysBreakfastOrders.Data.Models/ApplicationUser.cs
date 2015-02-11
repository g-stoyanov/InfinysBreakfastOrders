using InfinysBreakfastOrders.Data.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
namespace InfinysBreakfastOrders.Data.Models
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Index]
        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }

        public System.DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public System.DateTime? ModifiedOn { get; set; }
    }
}
