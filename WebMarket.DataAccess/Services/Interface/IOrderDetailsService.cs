using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IOrderDetailsService
    {
        public void add(OrderDetails Entiny);

        public IEnumerable<OrderDetails> GetAll();
        public OrderDetails GetfirstOrDefaulte(Expression<Func<OrderDetails, bool>> filter);
        public void remove(OrderDetails Entiny);

        public void update(OrderDetails Entiny);
        public  void RemoveRange(IEnumerable<OrderDetails> Entiny);
    }
}
