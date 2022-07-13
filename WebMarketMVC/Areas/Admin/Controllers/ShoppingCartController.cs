using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModel;

namespace WebMarketMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _db;

        public ShoppingCartController(IShoppingCartService db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var ClaimIdentity = (ClaimsIdentity)User.Identity;
            var Claim = ClaimIdentity.FindFirst(ClaimTypes.NameIdentifier).ToString();

            ShoppingCartVM shoppingCartVm = new ShoppingCartVM()
            {
                ListCarts = _db.GetAll(Claim)
            };
            return View(shoppingCartVm);
        }


        //Get
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
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
            if (Id == 0)
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
