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
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
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

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Update(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

    }
}
