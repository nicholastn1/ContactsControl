using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Helper;
using ContactsControl.Models;
using ContactsControl.Repository;
using Microsoft.AspNetCore.Http;

namespace ContactsControl.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _session;
        public LoginController(IUserRepository userRepository, IUserSession session)
        {
            _userRepository = userRepository;
            _session = session;
        }
        public IActionResult Index()
        {
            // If user logged in, redirect to home

            if (_session.SearchUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult LogOut()
        {
            _session.OverUserSession();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchForLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.ValidPassword(loginModel.Password))
                        {
                            _session.StartUserSession(user);
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