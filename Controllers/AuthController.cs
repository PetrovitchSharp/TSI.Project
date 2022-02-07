using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSI.DAL;
using TSI.Helpers;
using TSI.Models;

namespace TSI.Controllers
{
    public class AuthController : Controller
    {
        private DataContext _dataContext = new DataContext();
        public object AuthenticateHelper { get; private set; }

		[HttpGet]
        [Route("Auth")]
        public IActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Auth")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

	        if (ModelState.IsValid)
            {
                User user = await _dataContext.Users
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await AuthenticationHelper.Authenticate(model.Email, HttpContext); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неверный email или пароль!");
            }
            return View("Auth",model);
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }


}
