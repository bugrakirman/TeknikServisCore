﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeknikServisCore.DAL;
using TeknikServisCore.Models.IdentityModels;
using TeknikServisCore.Models.ViewModels;
using TeknikServisCore.Models.Enums;
using AutoMapper;

namespace TeknikServisCore.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;


        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {

                TempData["Message"] = ("Kayıt işlemi başarısız oldu. Girdiğiniz Bilgileri kontrol ediniz.");
                return View("Register", model);
            }
            else
            {
                var user = Mapper.Map<ApplicationUser>(model);

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await CreateRoles();

                    if (_userManager.Users.Count() == 1)
                    {
                        await _userManager.AddToRoleAsync(user, IdentityRoles.Admin.ToString());
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, IdentityRoles.User.ToString());
                    }

                    return RedirectToAction("Login");
                }
                else
                {
                    var errMsg = "";

                    foreach (var error in result.Errors)
                    {
                        errMsg += error.Code;
                    }


                    TempData["Message"] = (errMsg);
                    return View("Register", model);
                }


            }

        }

        private async Task CreateRoles()
        {
            var roleNames = Enum.GetNames(typeof(IdentityRoles));

            foreach (var roleName in roleNames)
            {
                if (!_roleManager.RoleExistsAsync(roleName).Result)
                {
                    await _roleManager.CreateAsync(new ApplicationRole()
                    {
                        Name = roleName
                    });
                }
            }
        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Register", "Account");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
            }

            return View(model);
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}