using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModel;

namespace WebMarket.DataAccess.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void add(ProductVM Entity)
        {
            _db.Products.Add(Entity.Product);
            _db.SaveChanges();
        }

        public void update(ProductVM Entity)
        {
            var UpdateProduct = _db.Products.FirstOrDefault(p => p.Id == Entity.Product.Id);
            if (UpdateProduct != null)
            {
                Entity.Product.Title = UpdateProduct.Title;
                Entity.Product.Description = UpdateProduct.Description;
                Entity.Product.Price = UpdateProduct.Price;
                Entity.Product.ShortDescription = UpdateProduct.ShortDescription;
                Entity.Product.ISBN = UpdateProduct.ISBN;
                Entity.Product.Author = UpdateProduct.Author;
                Entity.Product.ListPrice = UpdateProduct.ListPrice;
                Entity.Product.Price50 = UpdateProduct.Price50;
                Entity.Product.Price100 = UpdateProduct.Price100;
                Entity.Product.ImgeUrl = UpdateProduct.ImgeUrl;
                Entity.Product.ImageTitle = UpdateProduct.ImageTitle;
                Entity.Product.ImageAlt = UpdateProduct.ImageAlt;
                Entity.Product.CategoryId = UpdateProduct.CategoryId;
                Entity.Product.CoverTypeId = UpdateProduct.CoverTypeId;
            }
        }

        public void Remove(Product Entity)
        {
            _db.Products.Remove(Entity);
            _db.SaveChanges();
        }

        public void RemoveRenge(Product Entity)
        {
            _db.Products.RemoveRange(Entity);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> query = _db.Products.Include(c=>c.Category).Include(c=>c.CoverType);
            return query;
        }

        public Product GetFirstOrDefulte(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}
