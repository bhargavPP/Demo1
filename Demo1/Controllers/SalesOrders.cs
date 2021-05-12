using Demo1.DbContext;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    public class SalesOrdersController : Controller
    {
        private readonly Demo1DbContext _db;

        public SalesOrdersController(Demo1DbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SalesOrder.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SalesOrders SalesOrders)
        {
            if (ModelState.IsValid)
            {
                _db.Add(SalesOrders);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(SalesOrders);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var SalesOrders = _db.SalesOrder.Find(Id);
            if (SalesOrders == null)
            {
                return NotFound();
            }
            _db.SalesOrder.Remove(SalesOrders);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var SalesOrders = _db.SalesOrder.Find(Id);
            if (SalesOrders == null)
            {
                return NotFound();
            }
            return View(SalesOrders);
        }

        [HttpPost]
        public IActionResult Edit(SalesOrders SalesOrders)
        {
            if (ModelState.IsValid)
            {
                _db.Update(SalesOrders);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(SalesOrders);
        }
    }
}
