using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IOrderHeaderService
    {
        public void add(OrderHeader Entiny);

        public IEnumerable<OrderHeader> GetAll();
        public OrderHeader GetfirstOrDefaulte(Expression<Func<OrderHeader, bool>> filter);
        public void remove(OrderHeader Entiny);

        public void update(OrderHeader Entiny);
        public  void RemoveRange(IEnumerable<OrderHeader> Entiny);
        public void UpdateStatus(int id,string OrderStatus,string? PaymentStatus=null);
    }
}
