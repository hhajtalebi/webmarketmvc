using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICategoryService
    {
        public void add(Category Entiny);

        public IEnumerable<Category> GetAll();
        public Category GetfirstOrDefaulte(Expression<Func<Category,bool>> filter);
        public void remove(Category Entiny);

        public void update(Category Entiny);
        public  void RemoveRange(IEnumerable<Category> Entiny);
    }
}
