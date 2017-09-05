using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IMSApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //Extended
        public User User { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<IMSApplication.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Size> Sizes { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Variety> Varieties { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.InvoiceItem> InvoiceItems { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Invoice> Invoices { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Voucher> Vouchers { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Sales> Sales { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Channel> Channels { get; set; }

        public System.Data.Entity.DbSet<IMSApplication.Models.Receipt> Receipts { get; set; }
    }
}