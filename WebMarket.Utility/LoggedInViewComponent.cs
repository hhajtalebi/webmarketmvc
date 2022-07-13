using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Data;
using WebMarket.Models.ViewModel;

namespace WebMarket.Utility
{
    public class LoggedInViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public LoggedInViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ProductVM productVm = new ProductVM()
            {
                NameUser = _db.ApplicationUsers.First(u => User.Identity != null && u.Email == User.Identity.Name).FullName
            };

            return View("~/Areas/Customer/Views/Shared/Component/LoggedInUser.cshtml", productVm);
        }
    }
}
