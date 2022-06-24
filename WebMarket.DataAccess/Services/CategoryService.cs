using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(Category Entiny)
        {
            _context.Categories.Add(Entiny);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> query = _context.Categories;
            return query;
        }

        public Category GetfirstOrDefaulte(Expression<Func<Category, bool>> filter)
        {
           IQueryable<Category> query= _context.Categories;
           query= query.Where(filter);
           return query.FirstOrDefault();
        }

        public void remove(Category Entiny)
        {
            _context.Categories.Remove(Entiny);
            _context.SaveChanges();
        }

        public void update(Category Entiny)
        {
            _context.Categories.Update(Entiny);
            _context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<Category> Entiny)
        {
           _context.Categories.RemoveRange(Entiny);
           _context.SaveChanges();
        }
    }
}
