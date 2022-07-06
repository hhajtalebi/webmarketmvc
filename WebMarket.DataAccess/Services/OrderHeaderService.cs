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
    public class OrderHeaderService: IOrderHeaderService
    {
        private readonly ApplicationDbContext _context;

        public OrderHeaderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(OrderHeader Entiny)
        {
            _context.OrderHeaders.Add(Entiny);
            _context.SaveChanges();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            IEnumerable<OrderHeader> query = _context.OrderHeaders;
            return query;
        }

        public OrderHeader GetfirstOrDefaulte(Expression<Func<OrderHeader, bool>> filter)
        {
           IQueryable<OrderHeader> query= _context.OrderHeaders;
           query= query.Where(filter);
           return query.FirstOrDefault();
        }

        public void remove(OrderHeader Entiny)
        {
            _context.OrderHeaders.Remove(Entiny);
            _context.SaveChanges();
        }

        public void update(OrderHeader Entiny)
        {
            _context.OrderHeaders.Update(Entiny);
            _context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<OrderHeader> Entiny)
        {
           _context.OrderHeaders.RemoveRange(Entiny);
           _context.SaveChanges();
        }

        public void UpdateStatus(int id, string OrderStatus, string? PaymentStatus = null)
        {
            var OrderFromDb = _context.OrderHeaders.FirstOrDefault(o => o.Id == id);
            if (OrderFromDb!=null)
            {
                OrderFromDb.OrderStasus = OrderStatus;
                if (PaymentStatus!=null)
                {
                    OrderFromDb.PaymentStasus = PaymentStatus;
                }
            }
           
        }
    }
}
