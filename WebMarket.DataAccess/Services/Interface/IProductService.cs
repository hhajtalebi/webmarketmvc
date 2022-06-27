using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;
using WebMarket.Models.ViewModel;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IProductService
    {
        public void add(ProductVM Entity);
        public void update(Product Entity);
        public void Remove(Product Entity);
        public  void RemoveRenge(Product Entity);
        public IEnumerable<Product> GetAll();
        public Product GetFirstOrDefulte(Expression<Func<Product, bool>> filter);
    }
}
