using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMarket.DataAccess.Data;
using WebMarket.Models;

namespace WebMarketMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult  Index()
        {

            IEnumerable<ApplicationUsers> users = _context.ApplicationUsers;
            return View(users);
        }
    }
}
