using Demo1.DbContext;
using Demo1.Models;
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
            return View(ModelVM);
        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _db.Models.Add(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            ModelVM.Model = _db.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == Id);
            if (ModelVM.Model == null)
            {
                return NotFound();
            }
            return View(ModelVM);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(int Id)
        {

            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _db.Update(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Model model = _db.Models.Find(Id);
            if (model == null)
            {
                return NotFound();
            }
            _db.Models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [AllowAnonymous]
        [HttpGet("api/models/{MakeID}")]
        public IEnumerable<ModelResources> Models(int MakeID)
        {
            //return _db.Models.ToList().Where(m=>m.MakeID==MakeID);
            //////////////Autommaper user/////////////
            //create mapper configuration
            var models = _db.Models.ToList().Where(m => m.MakeID == MakeID).ToList();
            //var config = new MapperConfiguration(mc => mc.CreateMap<Model, ModelResources>());
            //var mapper = new Mapper(config);

            var modelResources = _mapper.Map<List<Model>, List<ModelResources>>(models);

            return modelResources;
            //////////////Autommaper user/////////////
            //second method to map 
            //var models = _db.Models.ToList();
            //var modelResources = models.Select(m => new ModelResources { Id = m.Id, Name = m.Name }).ToList();

            //return modelResources;
        }
    }
}
