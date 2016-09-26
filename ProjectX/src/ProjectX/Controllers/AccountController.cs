using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectX.ViewModels;

using ProjectX.Models;
using ProjectX.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectX.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ProjectXUser> _userManagerService;
        private SignInManager<ProjectXUser> _signInManagerService;
        private RoleManager<IdentityRole> _roleManagerService;

        //private MyDBContext _myDb;

        private IUserRepository _userRepo;
        private IRoleRepository _roleRepo;
        public AccountController(IUserRepository userRepo, IRoleRepository roleRepo, UserManager<ProjectXUser> userManagerService, SignInManager<ProjectXUser> signInManagerService, RoleManager<IdentityRole> roleManagerService)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;

            _userManagerService = userManagerService;
            _signInManagerService = signInManagerService;
            _roleManagerService = roleManagerService;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new ProjectXUser
                {
                    UserName = vm.Username,
                    Email = vm.Email
                };

                //save to db
                IdentityResult result = await _userManagerService.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            LoginViewModel vm = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManagerService.PasswordSignInAsync(vm.Username, vm.Password, vm.RememberMe, false);


                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(vm.ReturnUrl) && Url.IsLocalUrl(vm.ReturnUrl))
                    {
                        return Redirect(vm.ReturnUrl);
                        //return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            ModelState.AddModelError("", "Username or Password Incorrect");
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManagerService.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Manage()
        {
            ManageViewModel vm = new ManageViewModel
            {
                Users = _userRepo.GetAll()
            };


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManagerService.CreateAsync((new IdentityRole(vm.Role)));

                return RedirectToAction("Index", "Home");
            }

            return View(vm);
        }

        [HttpGet]

        public async Task<IActionResult> AddToRole(int id)
        {

            AddToRoleViewModel vm = new AddToRoleViewModel();

            vm.id = id;
            vm.roles = _roleRepo.GetAll();

            return View(vm);
        }

    }
}