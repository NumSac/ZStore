using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Data;

namespace ZStore.Infrastructure.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            // migrations if they are not applied
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
                // todo: implement logger (not only here...)
            }
            catch (Exception) { }

            // create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager
                    .CreateAsync(new IdentityRole(SD.Role_Company))
                    .GetAwaiter()
                    .GetResult();
                _roleManager
                    .CreateAsync(new IdentityRole(SD.Role_Employee))
                    .GetAwaiter()
                    .GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();

                //if roles are not created, then we will create admin user as well
                _userManager
                    .CreateAsync(
                        new ApplicationUser
                        {
                            UserName = "admin@dotnetmastery.com",
                            Email = "admin@dotnetmastery.com",
                            FirstName = "Zacharias",
                            LastName = "Dohmann",
                            PhoneNumber = "1112223333",
                            StreetAddress = "test 123 Ave",
                            PostalCode = "23422",
                            City = "Chicago"
                        },
                        "Admin123*"
                    )
                    .GetAwaiter()
                    .GetResult();

                var user = _context.ApplicationUsers.FirstOrDefault(
                    u => u.Email == "admin@dotnetmastery.com"
                );
                _userManager.AddToRoleAsync(user!, SD.Role_Admin).GetAwaiter().GetResult();
            }
        }
    }
}
