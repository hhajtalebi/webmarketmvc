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
                    Product = _db.GetFirstOrDefulte(p=>p.Id==Id),
                    CategorySelectList = _categoryService.GetAll()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }),
                    CoverTypeSelectList = _coverTypeService.GetAll()
                        .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                };
                return View(productVM);

            }

            
           
           
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj,IFormFile? file)
        {
            if (obj.Product.Id==null||obj.Product.Id==0)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (ModelState.IsValid)
                {
                    ///نام فایل
                    string filename = Guid.NewGuid().ToString();
                    ///مسیر آپلود
                    var uplodes = Path.Combine(wwwRootPath, @"Image/Product");
                    ///ادامه نام فایل
                    var extenstion = Path.GetExtension(file.FileName);

                    using (var filestrms = new FileStream(Path.Combine(uplodes, filename + extenstion), FileMode.Create))
                    {
                        file.CopyTo(filestrms);
                    }

                    obj.Product.ImgeUrl = @"/Image/Product/" + filename + extenstion;

                    _db.add(obj);
                    TempData["succsess"] = "محصول  با موفقیت ویرایش  شد";

                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
            

            return View();

        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var DeleteProduct = _db.GetFirstOrDefulte(p => p.Id == Id);
            if (DeleteProduct != null)
            {
                return View(DeleteProduct);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var DeleteProduct = _db.GetFirstOrDefulte(p => p.Id == Id);
            if (DeleteProduct != null)
            {
                _db.Remove(DeleteProduct);
                TempData["delete"] = "محصول  با موفقیت حذف  شد";
                return RedirectToAction("Index");
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


        #endregion


    }
}
