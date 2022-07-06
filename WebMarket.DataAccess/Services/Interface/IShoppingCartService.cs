using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IShoppingCartService
    {
        public void add(ShoppingCart Entiny);

        public IEnumerable<ShoppingCart> GetAll();
        public ShoppingCart GetfirstOrDefaulte(Expression<Func<ShoppingCart, bool>> filter);
        public void remove(ShoppingCart Entiny);

        public void update(ShoppingCart Entiny);
        public  void RemoveRange(IEnumerable<ShoppingCart> Entiny);
    }
}
