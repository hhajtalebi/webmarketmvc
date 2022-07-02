using System.Linq.Expressions;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICompanyServic
    {
        public void add(Company Entiny);

        public IEnumerable<Company> GetAll();
        public Company GetfirstOrDefaulte(Expression<Func<Company, bool>> filter);
        public void remove(Company Entiny);

        public void update(Company Entiny);
        public  void RemoveRange(IEnumerable<Company> Entiny);
    }
}
