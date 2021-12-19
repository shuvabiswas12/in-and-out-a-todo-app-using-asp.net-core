using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        // we can use "const" keyword instead of "readonly" keyword.
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objlist = _db.Expenses;
            return View(objlist);
        }

        // GET - create
        public IActionResult Create()
        {
            return View();
        }

        // POST - create
        [HttpPost]
        public IActionResult Create(Expense obj)
        {
            _db.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
