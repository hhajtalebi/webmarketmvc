using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models.ViewModel;

namespace WebMarketMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _db;
        private readonly ICategoryService _categoryService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductService db, ICategoryService categoryService, ICoverTypeService coverTypeService, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _categoryService = categoryService;
            _coverTypeService = coverTypeService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Product Obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Obj.CreateDate = DateTime.Now;
        //        _db.add(Obj);
        //        TempData["success"] = "محصول جدید با موفقیت ایجاد شد";
        //        return RedirectToAction("Index");
        //    }

        //    return View(Obj);
        //}
        [HttpGet]
        public IActionResult Upsert(int? Id)
        {
            //IEnumerable<SelectListItem> CategorySelectlist = _categoryService.GetAll().Select(c => new SelectListItem
            //{
            //    Text = c.Name, Value = c.Id.ToString()
            //});

            //IEnumerable<SelectListItem> Covertypeselectlist = _coverTypeService.GetAll().Select(c => new SelectListItem
            //{
            //    Text = c.Name,
            //    Value = c.Id.ToString()
            //});

            if (Id == null || Id == 0)
            {
                ProductVM productVM = new()
                {
                    Product = new(),
                    CategorySelectList = _categoryService.GetAll()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }),
                    CoverTypeSelectList = _coverTypeService.GetAll()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                };
                /////Create
                //  ViewBag.Categorylist = CategorySelectlist;
                //ViewBag.CoverTypelist = Covertypeselectlist;


                return View(productVM);
            }
            else
            {

                ProductVM productVM = new()
                {
                    Product = _db.GetFirstOrDefulte(p => p.Id == Id),
                    CategorySelectList = _categoryService.GetAll()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }),
                    CoverTypeSelectList = _coverTypeService.GetAll()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                };
                return View(productVM);

            }




        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Image\Product");
                    var extenstion = Path.GetExtension(file.FileName);

                    if (obj.Product.ImgeUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.ImgeUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStrems = new FileStream(Path.Combine(uploads, fileName + extenstion), FileMode.Create))
                    {
                        file.CopyTo(fileStrems);
                    }

                    obj.Product.ImgeUrl = fileName + extenstion;
                }

                if (obj.Product.Id == null || obj.Product.Id == 0)
                {
                    _db.add(obj);
                    TempData["success"] = "محصول  با موفقیت ثبت  شد";

                    return RedirectToAction("Index");
                }
                else
                {
                    _db.update(obj.Product);
                    TempData["edite"] = "محصول  با موفقیت ویرایش  شد";
                    return RedirectToAction("Index");

                }
            }
            


            return View();

        }

       
       

        #region API CALL

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _db.GetAll();
            return Json(new { data = productList });

        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _db.GetFirstOrDefulte(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "خطا در حذف " });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImgeUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _db.Remove(obj);
            return Json(new { success = true, message = "حذف موفقیت آمیز بود" });
        }

        #endregion


    }
}
