using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartService(ApplicationDbContext db)
        {
            _context = db;
        }

       
        public void add(ShoppingCart entity)
        {
            _context.ShoppingCarts.Add(entity);
            _context.SaveChangesAsync();
        }
        
        public IEnumerable<ShoppingCart> GetAll()
        {
            IEnumerable<ShoppingCart> query = _context.ShoppingCarts.Include(c => c.ApplicationUsers)
                .Include(p => p.Product);
            return query;
        }

        public ShoppingCart GetfirstOrDefaulte(Expression<Func<ShoppingCart, bool>> filter)
        {
           IQueryable<ShoppingCart> query= _context.ShoppingCarts;
           query= query.Where(filter);
           return query.FirstOrDefault();
        }

        public void remove(ShoppingCart Entiny)
        {
            _context.ShoppingCarts.Remove(Entiny);
            _context.SaveChanges();
        }

        public void update(ShoppingCart Entiny)
        {
            _context.ShoppingCarts.Update(Entiny);
            _context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<ShoppingCart> Entiny)
        {
           _context.ShoppingCarts.RemoveRange(Entiny);
           _context.SaveChanges();
        }
    }
}
