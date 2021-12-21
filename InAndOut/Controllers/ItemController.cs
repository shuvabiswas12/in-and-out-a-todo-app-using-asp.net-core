﻿using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        // we can use "const" keyword instead of "readonly" keyword.
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)



        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objlist = _db.Items;
            return View(objlist);
        }

        // GET - create
        public IActionResult Create()
        {
            return View();
        }

        // POST - create
        [HttpPost]
        public IActionResult Create(Item obj)
        {
            _db.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
