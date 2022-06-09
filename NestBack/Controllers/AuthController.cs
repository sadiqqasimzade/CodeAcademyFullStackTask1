using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NestBack.Models;
using NestBack.ViewModels.Auth;
using System;
using System.Threading.Tasks;
using static NestBack.Utilies.Constants;

namespace NestBack.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthController(UserManager<AppUser> manager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult Register()
        {

            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginVM login, string ReturnUrl)
        {
            AppUser user;
            if (!ModelState.IsValid) return View(login);
            if (login.UsernameOrEmail.Contains("@"))
                user = await _userManager.FindByEmailAsync(login.UsernameOrEmail);
            else
                user = await _userManager.FindByNameAsync(login.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError("", "Wrong Login Or Password");
                return View(login);
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Locked until " + user.LockoutEnd.ToString());
                return View(login);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Wrong Login Or Password");
                return View(login);
            }
            if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new AppUser()
            {
                Name = register.FirstName,
                Surname = register.LastName,
                UserName = register.UserName,
                Email = register.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(appUser, register.Password);
            if (!result.Succeeded)
                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);


            await _userManager.AddToRoleAsync(appUser, UserRoles.Member.ToString());

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePassVM targetuser)
        {
            AppUser user;
            if (!ModelState.IsValid || targetuser == null) return View(targetuser);
            if (targetuser.UsernameOrEmail.Contains("@"))
                user = await _userManager.FindByEmailAsync(targetuser.UsernameOrEmail);
            else
                user = await _userManager.FindByNameAsync(targetuser.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError("", "Wrong Username or Pass");
                return View(targetuser);
            }
            var result = await _userManager.ChangePasswordAsync(user, targetuser.Password, targetuser.ChangedPassword);


            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(targetuser);
            }
            return RedirectToAction("Index","Home");
        }

        public async Task CreateRoles()
        {
            foreach (var item in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString())) await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
            }
        }
    }
}
