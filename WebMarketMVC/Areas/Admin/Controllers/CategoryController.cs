using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarketMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _db;

        public CategoryController(ICategoryService db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> categorieslist = _db.GetAll();
            return View(categorieslist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","مقدار فیلد ترتیب نمایس نباید با مقدار نام برابر باشد");
            }

            List<Category> diplayorderrepet = _db.GetAll().Where(u=>u.DisplayOrder==obj.DisplayOrder).ToList();

            if (diplayorderrepet.Count>0)
            {
                return View(obj);
            }


            if (ModelState.IsValid)
            {
                obj.CreatedDateTime=DateTime.Now;
                _db.add(obj);
                TempData["success"] = "دسته جدید با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        /// <summary>
        /// Get
       
        public IActionResult Edite(int? Id)
        {
            if (Id==null||Id==0)
            {
                return NotFound();
            }

            var categoryfromdbfrist = _db.GetfirstOrDefaulte(u => u.Id == Id);
            if (categoryfromdbfrist==null)
            {
                return NotFound();
            }

            return View(categoryfromdbfrist);
        }

        [HttpPost]
        public IActionResult Edite(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار فیلد ترتیب نمایس نباید با مقدار نام برابر باشد");
            }
           

            if (ModelState.IsValid)
            {
                _db.update(obj);
                TempData["edite"] = "دسته جدید با موفقیت ویرایش  شد";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        //Get
        public IActionResult Delete(int? Id)
        {
            if (Id==null||Id==0)
            {
                return NotFound();
            }

            var category = _db.GetfirstOrDefaulte(u => u.Id == Id);
            if (category==null)
            {
                return NotFound();
            }

            return View(category);
        }
        //post
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            if (Id==0)
            {
                return NotFound();
            }

            var obj = _db.GetfirstOrDefaulte(u => u.Id == Id);
            _db.remove(obj);
            TempData["delete"] = "دسته جدید با موفقیت حذف  شد";
            return RedirectToAction("Index");
        }




    }
}
