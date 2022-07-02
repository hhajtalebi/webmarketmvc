using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarketMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyServic _db;

        public CompanyController(ICompanyServic db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companyslist = _db.GetAll();
            return View(companyslist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company obj)
        {
           
            
            if (ModelState.IsValid)
            {
               
                _db.add(obj);
                TempData["success"] = "کمپانی  با موفقیت ایجاد شد";
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

            var Companyfromdbfrist = _db.GetfirstOrDefaulte(u => u.Id == Id);
            if (Companyfromdbfrist == null)
            {
                return NotFound();
            }

            return View(Companyfromdbfrist);
        }

        [HttpPost]
        public IActionResult Edite(Company obj)
        {
           

            if (ModelState.IsValid)
            {
                _db.update(obj);
                TempData["edite"] = "کمپانی  با موفقیت ویرایش  شد";
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

            var Company = _db.GetfirstOrDefaulte(u => u.Id == Id);
            if (Company == null)
            {
                return NotFound();
            }

            return View(Company);
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
            TempData["delete"] = "کمپانی  با موفقیت حذف  شد";
            return RedirectToAction("Index");
        }




    }
}
