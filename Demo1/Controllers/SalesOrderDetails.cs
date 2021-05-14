using Demo1.DbContext;
using Demo1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    public class SalesOrderDetailsController : Controller
    {
        private readonly Demo1DbContext _db;

        [BindProperty]
        public SalesViewModel SalesVM { get; set; }

        public SalesOrderDetailsController(Demo1DbContext db)
        {
            _db = db;

            SalesVM = new SalesViewModel()
            {
                SalesOrders = _db.SalesOrder.ToList(),
                SalesOrderDetails = new Models.SalesOrderDetails()
            };
        }
        public IActionResult Index2()
        {
            var SalesDetail = _db.SalesOrderDetail.Include(m => m.SalesOrders);
            return View(SalesDetail.ToList());
        }
        
        private IActionResult Error()
        {
            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            return View(SalesVM);
        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(SalesVM);
            }
            _db.SalesOrderDetail.Add(SalesVM.SalesOrderDetails);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index2));
        }

        public IActionResult Edit(int Id)
        {
            SalesOrderDetails salesOrderDetails = _db.SalesOrderDetail.Include(m => m.SalesOrders).SingleOrDefault(m => m.OrderID == Id);
            if (SalesVM.SalesOrderDetails == null)
            {
                return NotFound();
            }
            return View(SalesVM);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(int Id)
        {

            if (!ModelState.IsValid)
            {
                return View(SalesVM);
            }
            _db.Update(SalesVM.SalesOrderDetails);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index2));
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            SalesOrderDetails salesOrderDetails = _db.SalesOrderDetail.Find(Id);
            if (salesOrderDetails == null)
            {
                return NotFound();
            }
            _db.SalesOrderDetail.Remove(salesOrderDetails);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index2));

        }
         
    }
}
