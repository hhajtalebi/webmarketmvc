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

        public void update(Product Entity)
        {
            var UpdateProduct = _db.Products.FirstOrDefault(p => p.Id == Entity.Id);
            if (UpdateProduct != null)
            {
                UpdateProduct.Title = Entity.Title;
                UpdateProduct.Description = Entity.Description;
                UpdateProduct.Price = Entity.Price;
                UpdateProduct.ShortDescription = Entity.ShortDescription;
                UpdateProduct.ISBN = Entity.ISBN;
                UpdateProduct.Author = Entity.Author;
                UpdateProduct.ListPrice = Entity.ListPrice;
                UpdateProduct.Price50 = Entity.Price50;
                UpdateProduct.Price100 = Entity.Price100;
                 UpdateProduct.ImgeUrl= Entity.ImgeUrl ;
                 UpdateProduct.ImageTitle = Entity.ImageTitle;
                 UpdateProduct.ImageAlt = Entity.ImageAlt;
                 UpdateProduct.CategoryId = Entity.CategoryId;
                 UpdateProduct.CoverTypeId = Entity.CoverTypeId;
            }

            _db.SaveChanges();
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
