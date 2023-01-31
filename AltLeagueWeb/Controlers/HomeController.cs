﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using AltLeague.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.Scripting;
using System.Security.Claims;

namespace AltLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppUserRepository _userRepository;
        

        public HomeController(ILogger<HomeController> logger, IAppUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = (AppUserRepository)userRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.UserRoleName = User.UserRoleName();
            return View();
        }


        [AllowAnonymous]
        public async Task<IActionResult> Login(CredentialViewModel credential)
        {
            // This is for development purposes only
            TempData.Clear();

            //IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            //foreach (ModelError error in allErrors)
            //{
            //    Debug.WriteLine(error.Exception);
            //    Debug.WriteLine(error.ErrorMessage);
            //}

            if (ModelState.IsValid)
            {
                App_User_Model user = _userRepository.UserGetByCredentials(credential.user_name, credential.password);

                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.full_name),
                        new Claim(ClaimTypes.Email, user.email),
                        new Claim(ClaimTypes.Role, user.lk_user_role.lk_user_role_key.ToString()),
                        new Claim("UserName", user.user_name),
                        new Claim("FirstName", user.first_name),
                        new Claim("LastName", user.last_name),
                        new Claim("NickName", user.nick_name),
                        new Claim("UserKey", user.user_key.ToString()),
                    };

                    var identity = new ClaimsIdentity(claims, "UserAuth_PA_AltLeague");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("UserAuth_AltLeague", claimsPrincipal);
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        //[AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("UserAuth_AltLeague"); 
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


  
    }
}