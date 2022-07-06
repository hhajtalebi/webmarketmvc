﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModel;

namespace WebMarketMVC.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
      private readonly IProductService _productService;
      private readonly IShoppingCartService _shoppingCartService;

      public HomeController(IProductService productService, IShoppingCartService shoppingCartService)
      {
          _productService = productService;
          _shoppingCartService = shoppingCartService;
      }

      public IActionResult Index()
      {
          var product = _productService.GetAll();

            return View(product);
        }
      [HttpGet]
      public IActionResult ProductDetails(int productId)
      {
          ShoppingCart shoppingCart = new ShoppingCart()
          {
              Product = _productService.GetFirstOrDefulte(p => p.Id == productId),
              ProductId = productId,
              Count = 1
          };
          return View(shoppingCart);
      }
      [HttpPost]
      [ValidateAntiForgeryToken]
      [Authorize]
      public async Task<IActionResult>   ProductDetailsAsync(ShoppingCart Cart)
      {
          var claimIdentity = (ClaimsIdentity)User.Identity;
          var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
         Cart.ApplicationUserId = claim.Value;

          
              _shoppingCartService.add(Cart);
          

          return RedirectToAction("Index");
      }
    }
}
    

