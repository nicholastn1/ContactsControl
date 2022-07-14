using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Models;
using ContactsControl.Repository;

namespace ContactsControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchForLogin(login.Login);

                    if (user != null)
                    {
                        if (user.ValidPassword(login.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["ErrorMessage"] = "Password is not valid!";
                    }
                    TempData["ErrorMessage"] = "Login and/or Password is not valid!";
                }

                return View("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Login could not be done! Error details: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}