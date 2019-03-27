using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknikServisCore.DAL;
using TeknikServisCore.Models.IdentityModels;
using TeknikServisCore.Models.ViewModels;

namespace TeknikServisCore.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                 
            };

            return View();
        }
    }
}