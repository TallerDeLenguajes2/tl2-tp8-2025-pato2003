using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using tl2_tp8_2025_pato2003.ViewModels;
using tl2_tp8_2025_pato2003.Interfaces;

namespace tl2_tp8_2025_pato2003.Controllers
{
    public class LoginController : Controller
    {
        private readonly Interfaces.IAuthenticationService _authenticationService;

        public LoginController(Interfaces.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        } 

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username)||string.IsNullOrEmpty(model.Password))
            {
                model.ErrorMessage = "Debe ingresar usuario y contraseña";
                return View("Index", model);
            }

            if (_authenticationService.Login(model.Username, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }

            model.ErrorMessage ="Credenciales Invalidas";
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _authenticationService.Logout();
            return RedirectToAction("Index");
        }
    }

    
}