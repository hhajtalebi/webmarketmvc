using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarketMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _db;

        public ShoppingCartController(IShoppingCartService db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<ShoppingCart> shoppingCarts = _db.GetAll();
            return View(shoppingCarts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShoppingCart obj)
        {
            


            if (ModelState.IsValid)
            {
              
                _db.add(obj);
                TempData["success"] = "سبد خرید جدید با موفقیت ایجاد شد";
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
        public IActionResult Edite(ShoppingCart obj)
        {
           

            if (ModelState.IsValid)
            {
                _db.update(obj);
                TempData["edite"] = "سبد خرید با موفقیت ویرایش  شد";
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

            var shoppingCart = _db.GetfirstOrDefaulte(u => u.Id == Id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
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
            TempData["delete"] = "سبد خرید با موفقیت حذف  شد";
            return RedirectToAction("Index");
        }




    }
}
