using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarketMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypeController(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;
        }
        // GET: CoverTypeController
        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypeslist = _coverTypeService.GetAll();
            return View(coverTypeslist);
        }

     
       
        // GET: CoverTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoverTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            
            
                if (ModelState.IsValid)
                {
                    _coverTypeService.add(obj);
                TempData["success"] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Index");
                }
           
                return View();
            
        }

        // GET: CoverTypeController/Edit/5
        public IActionResult Edit(int Id)
        {
            var CoverTypelist = _coverTypeService.GetFirstOrDefaulte(c => c.Id == Id);
            if (CoverTypelist!=null)
            {
                return View(CoverTypelist);
            }
            return View();
        }

        // POST: CoverTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _coverTypeService.update(obj);
                TempData["edite"] = "بروز رسانی با موفقیت انجام شد";
                return RedirectToAction("Index");

            }

            return View();
           
        }

        // GET: CoverTypeController/Delete/5
        public IActionResult Delete(int? id)
        {
            var coverTypelist = _coverTypeService.GetFirstOrDefaulte(c => c.Id == id);
            if (coverTypelist!=null)
            {
                return View(coverTypelist);
            }
            return View();
        }

        // POST: CoverTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (id!=0)
            {
                var coverTypelist = _coverTypeService.GetFirstOrDefaulte(c => c.Id == id);

                _coverTypeService.remove(coverTypelist);
                TempData["delete"] = "دسته جدید با موفقیت حذف  شد";

                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
