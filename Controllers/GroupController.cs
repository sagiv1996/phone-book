using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using phoneBook.Models;
namespace phoneBook.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index(int? id)
        {
            PhoneBookPrimary book = PhoneBookPrimary.Create();
            Group group;
            if (id == null)
                group = book.Root;
            else
                group = (Group)book.getItemById(id.Value);

            return View(group);
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null)
                return View();
            Group group = new Group() { PerentId =id.Value };

            return View(group);

        }


        [HttpPost]
        public IActionResult Create(Group group)
        {
            if (!this.ModelState.IsValid)
            {
                return View(group);
            }
            ((Group) PhoneBookPrimary.Create().getItemById(group.ID)).addItem(group);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                itemInBook item = PhoneBookPrimary.Create().getItemById(id.Value);
                return View(item);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Group group)
        {
            ((Group)PhoneBookPrimary.Create().getItemById(group.ID)).Name = group.Name;

            return RedirectToAction("Index", new { id = group.ID });

        }

        [HttpGet]
        public IActionResult Delete (int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            return View(PhoneBookPrimary.Create().getItemById(id.Value));
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            Group group = (Group) PhoneBookPrimary.Create().getItemById(id);
            group.Parent.Items.Remove(group);
            return View();
        }


    }
}