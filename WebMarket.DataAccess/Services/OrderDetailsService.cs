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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(OrderDetails Entiny)
        {
            _context.OrderDetails.Add(Entiny);
            _context.SaveChanges();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            IEnumerable<OrderDetails> query = _context.OrderDetails;
            return query;
        }

        public OrderDetails GetfirstOrDefaulte(Expression<Func<OrderDetails, bool>> filter)
        {
           IQueryable<OrderDetails> query= _context.OrderDetails;
           query= query.Where(filter);
           return query.FirstOrDefault();
        }

        public void remove(OrderDetails Entiny)
        {
            _context.OrderDetails.Remove(Entiny);
            _context.SaveChanges();
        }

        public void update(OrderDetails Entiny)
        {
            _context.OrderDetails.Update(Entiny);
            _context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<OrderDetails> Entiny)
        {
           _context.OrderDetails.RemoveRange(Entiny);
           _context.SaveChanges();
        }
    }
}
