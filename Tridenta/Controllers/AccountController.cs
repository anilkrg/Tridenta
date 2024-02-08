using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tridenta.BAL.Interface;
using Tridenta.Model.ViewModel;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Tridenta.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRegistration _userRegistration;
        private readonly ILogger<AccountController> _logger;
        private readonly INotyfService _notfy;
        public AccountController(IUserRegistration userRegistration, ILogger<AccountController> logger)
        {
            IUserRegistration _userRegistration;
            _logger = logger;
        }
        public IActionResult Index()
        {

            _notfy.Success("Registration completed sucessfully", 3);
            _notfy.Error("Registration completed sucessfully", 3);
            _notfy.Warning("Registration completed sucessfully", 3);
            _notfy.Information("Registration completed sucessfully", 3);
            return View();
        }




        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(SignUpModel signUpModel)
        {
            try
            {
                var result = await _userRegistration.SignUp(signUpModel);
                if (result != null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                _logger.LogError(ex.Message);
            }


        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {

            var result = await _userRegistration.SignIn(signInModel);
            if (result != null)
            {

                var claims = new List<Claim>() {

                        new Claim(ClaimTypes.Name, signInModel.Email),
                    };


                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = signInModel.RememberMe
                });
                return RedirectToAction("Dash", "Dash");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login credential");

            }


            return View(signInModel);


        }
    }
}
