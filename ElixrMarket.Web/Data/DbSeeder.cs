using ElixrMarket.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web.Data
{
    public class DbSeeder
    {
        private readonly ElixrDataContext _context;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<ElixrUser> _userManager;
        private readonly ILogger<DbSeeder> _logger;

        public DbSeeder(
            ElixrDataContext context,
            RoleManager<IdentityRole<Guid>> roleManager,
            UserManager<ElixrUser> userManager,
            ILogger<DbSeeder> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public void SeedDev()
        {
            // must seed products first
           
        }

        public void SeedAdmin()
        {
            var admins = _userManager.GetUsersInRoleAsync(Constants.Roles.Admin).Result;

            if (admins.Count == 0)
            {
                var admin = new ElixrUser
                {
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                    UserName = "admin",
                };

                try
                {
                    var result = _userManager.CreateAsync(admin).Result;
                    // TODO: Change this to something secure
                    result = _userManager.AddPasswordAsync(admin, "P@$$W0rd").Result;
                    result = _userManager.AddToRoleAsync(admin, Constants.Roles.Admin).Result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
        }

        public void SeedDevUsers()
        {
            var customers = _userManager.GetUsersInRoleAsync(Constants.Roles.Customer).Result;

            if (customers.Count == 0)
            {
                var customer = new ElixrUser
                {
                    UserName = "Customer",
                    Email = "customer@email.com",
                    EmailConfirmed = true,
                };

                try
                {
                    var result = _userManager.CreateAsync(customer).Result;
                    result = _userManager.AddPasswordAsync(customer, "P@$$W0rd").Result;
                    result = _userManager.AddToRoleAsync(customer, Constants.Roles.Customer).Result;

                    customers.Add(customer);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            var developers = _userManager.GetUsersInRoleAsync(Constants.Roles.Developer).Result;

            if (developers.Count == 0)
            {
                var customer = new ElixrUser
                {
                    Email = "Developer@email.com",
                    EmailConfirmed = true,
                    UserName = "Developer",
                };

                try
                {
                    var result = _userManager.CreateAsync(customer).Result;
                    result = _userManager.AddPasswordAsync(customer, "P@$$W0rd").Result;
                    result = _userManager.AddToRoleAsync(customer, Constants.Roles.Developer).Result;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            var editors = _userManager.GetUsersInRoleAsync(Constants.Roles.Editor).Result;

            if (editors.Count == 0)
            {
                for (int i = 1; i < 3; i++)
                {
                    var editor = new ElixrUser
                    {
                        Email = "editor" + i + "@email.com",
                        EmailConfirmed = true,
                        UserName = "Editor" + i,
                    };

                    try
                    {
                        var result = _userManager.CreateAsync(editor).Result;
                        result = _userManager.AddPasswordAsync(editor, "P@$$W0rd").Result;
                        result = _userManager.AddToRoleAsync(editor, Constants.Roles.Editor).Result;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }

            var reviewers = _userManager.GetUsersInRoleAsync(Constants.Roles.Reviewer).Result;

            if (reviewers.Count == 0)
            {
                for (int i = 1; i < 6; i++)
                {
                    var reviewer = new ElixrUser
                    {
                        Email = "reviewer" + i + "@email.com",
                        EmailConfirmed = true,
                        UserName = "Reviewer" + i,
                    };

                    try
                    {
                        var result = _userManager.CreateAsync(reviewer).Result;
                        result = _userManager.AddPasswordAsync(reviewer, "P@$$W0rd").Result;
                        result = _userManager.AddToRoleAsync(reviewer, Constants.Roles.Reviewer).Result;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync(Constants.Roles.Customer).Result)
            {
                var role = new IdentityRole<Guid>();
                role.Name = Constants.Roles.Customer;
                var result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync(Constants.Roles.Developer).Result)
            {
                var role = new IdentityRole<Guid>();
                role.Name = Constants.Roles.Developer;
                var result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync(Constants.Roles.Editor).Result)
            {
                var role = new IdentityRole<Guid>();
                role.Name = Constants.Roles.Editor;
                var result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync(Constants.Roles.Reviewer).Result)
            {
                var role = new IdentityRole<Guid>();
                role.Name = Constants.Roles.Reviewer;
                var result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync(Constants.Roles.Admin).Result)
            {
                var role = new IdentityRole<Guid>();
                role.Name = Constants.Roles.Admin;
                var result = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedProducts()
        {
            if (_context.Products.Count() == 0)
            {
                var developer = _userManager.FindByNameAsync("Developer").Result;

                var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Sim Pharm", Price = 4.99m, Summary = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec sem condimentum odio auctor tristique vestibulum in lacus. Praesent eu ultricies lectus. Integer justo dui, luctus nec porttitor ac, lobortis quis sem. Aliquam erat volutpat. Sed vitae semper enim. Vivamus ut leo quis tortor scelerisque ultricies. Proin aliquet, arcu sit amet rhoncus rhoncus, nisl felis rhoncus sapien, sit amet iaculis velit quam sit amet nisi. ", Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec sem condimentum odio auctor tristique vestibulum in lacus. Praesent eu ultricies lectus. Integer justo dui, luctus nec porttitor ac, lobortis quis sem. Aliquam erat volutpat. Sed vitae semper enim. Vivamus ut leo quis tortor scelerisque ultricies. Proin aliquet, arcu sit amet rhoncus rhoncus, nisl felis rhoncus sapien, sit amet iaculis velit quam sit amet nisi.
    Aliquam cursus viverra erat, at luctus quam ornare eu. Vestibulum a pretium mi. Sed ultrices, mi in eleifend aliquet, velit tellus feugiat libero, eu tincidunt diam sapien ac sapien. In rutrum lacus quis mi cursus, non sollicitudin ligula porttitor. Curabitur sem leo, laoreet at sollicitudin eu, dapibus eu enim. Nullam libero mi, sollicitudin quis varius vitae, rhoncus laoreet neque. Mauris euismod fermentum urna vulputate tincidunt.
    Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Sed nec eros ac orci mollis pulvinar. Nam ornare efficitur turpis vel porta. Maecenas venenatis ultricies dui id elementum. Vivamus eget imperdiet neque. Nunc dignissim elit at ante imperdiet maximus. Pellentesque sodales ultricies nisi, eu maximus nunc scelerisque non. Sed malesuada eu ex id pulvinar. Phasellus interdum eleifend porttitor.
    Vestibulum nec faucibus nisl. Suspendisse pretium, nunc sit amet fringilla sollicitudin, nunc dui mattis ipsum, quis suscipit mauris augue a purus. Donec imperdiet scelerisque lectus a ultrices. Mauris ante leo, fermentum in orci et, ultricies laoreet erat. Donec sollicitudin ultricies nunc at scelerisque. Nulla et arcu nec lacus sagittis ornare. Nulla facilisi.
    In efficitur augue non consequat consectetur. Etiam tempus est eu mi efficitur, id fermentum augue iaculis. Mauris luctus cursus diam vitae mollis. Aliquam erat volutpat. Donec est sapien, dapibus sed interdum interdum, dignissim nec risus. Morbi tincidunt justo sit amet metus facilisis porttitor. Maecenas luctus lacus at metus feugiat scelerisque. Aenean sed diam condimentum, ornare nunc non, tempus metus. Nam semper sed ante vitae auctor. Vestibulum id hendrerit felis. Suspendisse porta ex eget dapibus pellentesque. Curabitur nec odio et lorem tincidunt porta. Pellentesque lacinia libero id lectus volutpat lobortis. Nulla facilisi. ", Status = ProductStatus.Gold, Url = "~/GOG_Galaxy_Hotline_Miami.exe", Developer = developer,
                        Requirements = new Requirements { RecGraph = "RTX 1070", MinGraph = "GTX 770", MinMem = "4GB DDR3", RecMem = "16GB DDR3", MinProc = "4th gen i5", RecProc = "8th gen i7", Storage = "5GB", OS = "Windows 10"} },

                    new Product { Id = 2, Name = "Yaro", Price = 4.99m, Summary = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec sem condimentum odio auctor tristique vestibulum in lacus. Praesent eu ultricies lectus. Integer justo dui, luctus nec porttitor ac, lobortis quis sem. Aliquam erat volutpat. Sed vitae semper enim. Vivamus ut leo quis tortor scelerisque ultricies. Proin aliquet, arcu sit amet rhoncus rhoncus, nisl felis rhoncus sapien, sit amet iaculis velit quam sit amet nisi. ", Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nec sem condimentum odio auctor tristique vestibulum in lacus. Praesent eu ultricies lectus. Integer justo dui, luctus nec porttitor ac, lobortis quis sem. Aliquam erat volutpat. Sed vitae semper enim. Vivamus ut leo quis tortor scelerisque ultricies. Proin aliquet, arcu sit amet rhoncus rhoncus, nisl felis rhoncus sapien, sit amet iaculis velit quam sit amet nisi.
    Aliquam cursus viverra erat, at luctus quam ornare eu. Vestibulum a pretium mi. Sed ultrices, mi in eleifend aliquet, velit tellus feugiat libero, eu tincidunt diam sapien ac sapien. In rutrum lacus quis mi cursus, non sollicitudin ligula porttitor. Curabitur sem leo, laoreet at sollicitudin eu, dapibus eu enim. Nullam libero mi, sollicitudin quis varius vitae, rhoncus laoreet neque. Mauris euismod fermentum urna vulputate tincidunt.
    Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Sed nec eros ac orci mollis pulvinar. Nam ornare efficitur turpis vel porta. Maecenas venenatis ultricies dui id elementum. Vivamus eget imperdiet neque. Nunc dignissim elit at ante imperdiet maximus. Pellentesque sodales ultricies nisi, eu maximus nunc scelerisque non. Sed malesuada eu ex id pulvinar. Phasellus interdum eleifend porttitor.
    Vestibulum nec faucibus nisl. Suspendisse pretium, nunc sit amet fringilla sollicitudin, nunc dui mattis ipsum, quis suscipit mauris augue a purus. Donec imperdiet scelerisque lectus a ultrices. Mauris ante leo, fermentum in orci et, ultricies laoreet erat. Donec sollicitudin ultricies nunc at scelerisque. Nulla et arcu nec lacus sagittis ornare. Nulla facilisi.
    In efficitur augue non consequat consectetur. Etiam tempus est eu mi efficitur, id fermentum augue iaculis. Mauris luctus cursus diam vitae mollis. Aliquam erat volutpat. Donec est sapien, dapibus sed interdum interdum, dignissim nec risus. Morbi tincidunt justo sit amet metus facilisis porttitor. Maecenas luctus lacus at metus feugiat scelerisque. Aenean sed diam condimentum, ornare nunc non, tempus metus. Nam semper sed ante vitae auctor. Vestibulum id hendrerit felis. Suspendisse porta ex eget dapibus pellentesque. Curabitur nec odio et lorem tincidunt porta. Pellentesque lacinia libero id lectus volutpat lobortis. Nulla facilisi. ", Status = ProductStatus.Bronze, Url = "~/GOG_Galaxy_Hotline_Miami.exe", Developer = developer,
                        Requirements = new Requirements { RecGraph = "RTX 1080", MinGraph = "GTX 780", MinMem = "8GB DDR3", RecMem = "16GB DDR3", MinProc = "6th gen i5", RecProc = "9th gen i7", Storage = "8GB", OS = "Windows 10"} },
                };

                _context.AddRange(products);

                _context.SaveChanges();
            }
        }
    }
}
