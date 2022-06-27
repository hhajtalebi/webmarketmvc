using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models.ViewModel;

namespace WebMarketMVC.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
      private readonly IProductService _productService;

      public HomeController(IProductService productService)
      {
          _productService = productService;
      }

      public IActionResult Index()
      {
          var product = _productService.GetAll();

            return View(product);
        }
      [HttpGet]
      public IActionResult ProductDetails(int id)
      {
          ShoppingCartVM shoppingCart = new ShoppingCartVM
          {
              Product = _productService.GetFirstOrDefulte(p => p.Id == id),
              Count = 1
          };
          return View(shoppingCart);
      }
    }
    

}