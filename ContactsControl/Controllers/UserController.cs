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
        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(UserWithoutPasswordModel userWithoutPassword)
        {
            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = userWithoutPassword.Id,
                        Name = userWithoutPassword.Name,
                        Login = userWithoutPassword.Login,
                        Email = userWithoutPassword.Email,
                        Profile = userWithoutPassword.Profile
                    };

                    user = _userRepository.Update(user);
                    TempData["SuccessMessage"] = "User edited successfully!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"User could not be edited! Error details: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult DeleteConfirmation(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _userRepository.Delete(id);

                if (deleted == true)
                {
                    TempData["SuccessMessage"] = "User deleted successfully!";
                }
                else
                {
                    TempData["SuccessMessage"] = "User could not be deleted";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"User could not be edited! Error details: {e.Message}";
                return RedirectToAction("Index");
            }
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
