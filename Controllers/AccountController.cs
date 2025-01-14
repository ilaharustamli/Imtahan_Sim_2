using Imtahan_Sim_2.DAL;
using Imtahan_Sim_2.Helpers;
using Imtahan_Sim_2.Models;
using Imtahan_Sim_2.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Imtahan_Sim_2.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = new AppUser
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.UserName
            };

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (!result.Succeeded)
            {
                AddErrorsToModelState(result.Errors);
                return View(vm);
            }

            await EnsureRoleExists(UserRoles.Admin.ToString());
            await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> CreateRole()
        {
            foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        private void AddErrorsToModelState(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private async Task EnsureRoleExists(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }


}

