using ControllerInBlazorDemo.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static ControllerInBlazorDemo.Pages.Login;

namespace ControllerInBlazorDemo.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public CookieController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;          
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel user)
        {
           
           var existing=await userManager.FindByNameAsync(user.Email);
            if (existing == null)
            {
                ModelState.AddModelError("", "User does not exists.");
                return Redirect("/login");
            }
            await signInManager.PasswordSignInAsync(existing, user.Password, false, false);
            return Redirect("/");
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
           
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
