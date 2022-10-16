using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.MiddleWares;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;
        public UserController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel LoginVm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }


            if (!ModelState.IsValid)
            {
                return View(LoginVm);
            }

            //Login
            UserViewModel userVM = await _userService.Login(LoginVm);

            if(userVM != null)
            {
                HttpContext.Session.Set<UserViewModel>("USER", userVM);

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            } 
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso incorrectos");
            }

            return View(LoginVm);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("USER");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public IActionResult Register()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _userService.AddAsync(vm);

            return RedirectToRoute(new { controller = "User", action = "Index" });

        }
    }
}
