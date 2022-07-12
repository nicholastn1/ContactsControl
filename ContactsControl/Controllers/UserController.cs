using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Models;
using ContactsControl.Repository;

namespace ContactsControl.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }
        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.SearchAll();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Add(user);
                    TempData["SuccessMessage"] = "User registered successfully!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"User could not be registered! Error details: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
