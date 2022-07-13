using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsControl.Models;
using ContactsControl.Repository;

namespace ContactsControl.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.SearchAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);

                if (deleted == true)
                {
                    TempData["SuccessMessage"] = "Contact deleted successfully!";
                }
                else
                {
                    TempData["SuccessMessage"] = $"Contact could not be deleted";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Contact could not be edited! Error details: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(contact);
                    TempData["SuccessMessage"] = "Contact registered successfully!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Contact could not be registered! Error details: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contact edited successfully!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Contact could not be edited! Error details: {e.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
