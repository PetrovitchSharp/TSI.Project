using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSI.DAL;
using TSI.Helpers;
using TSI.Models;

namespace TSI.Controllers
{
	public class RegisterController : Controller
	{

		public IActionResult Register()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserViewModel user)
        {
            var context = new DataContext();

            if (ModelState.IsValid)
			{
				var hasUserWithEmail = context.Users.Any(x => x.Email == user.Email);

				var flag = false;

				if (user.Password != user.CheckPassword)
				{
					ModelState.AddModelError("", "Пароли не совпадают");
					flag = true;
				}

				if (String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Name) || String.IsNullOrEmpty(user.Password) || String.IsNullOrEmpty(user.CheckPassword))
				{
					ModelState.AddModelError(string.Empty, "Заполнены не все обязательные поля!");
					flag = true;
				}


				if (hasUserWithEmail)
				{
					ModelState.AddModelError("", "Такая почта уже зарегистрирована");
					flag = true;
				}

				if (flag)
				{
					return View("Register", user);
				}


				var validatedUser = new User()
				{
					UserId = Guid.NewGuid(),
					Name = user.Name,
					Password = user.Password,
					Email = user.Email,

				};

				context.Users.Add(validatedUser);
				context.SaveChanges();

				await AuthenticationHelper.Authenticate(user.Email,  HttpContext); // аутентификация

				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "ФИО может содержать от 3 до 20 символов: латиница и кириллица");
				ModelState.AddModelError("", "Пароль должен содержать от 6 до 20 символов: латиница, цифры и подчёркивания");
				return View("Register", user);
			}
			
		}
    }
}
