using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            foreach(var obj in objlist)
            {
                obj.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == obj.ExpenseTypeId);
            }
            return View(objlist);
        }

        // GET - create
        public IActionResult Create()
        {
            // view bag code starts
            
            //IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.TypeDropDown = TypeDropDown;

            // view bag code ends


            // view model code starts
            ExpenseViewModel expenseViewModel = new ExpenseViewModel()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            // view model code ends

            return View(expenseViewModel);
        }

        // POST - create
        [HttpPost]
        public IActionResult Create(ExpenseViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // GET - delete view
        public IActionResult Delete(int? id) // this id is a optional ID. that is why we write "int?"
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id) // this id is a optional ID. that is why we write "int?"
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        // GET Update view
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Expense obj)
        { 
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
