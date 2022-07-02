using System.Linq.Expressions;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class CompanyServic : ICompanyServic
    {
        private readonly ApplicationDbContext _context;

        public CompanyServic(ApplicationDbContext context)
        {
            _context = context;
        }

        public void add(Company Entiny)
        {
            _context.Companies.Add(Entiny);
            _context.SaveChanges();
        }

        public IEnumerable<Company> GetAll()
        {
            IEnumerable<Company> query = _context.Companies;
            return query;
        }

        public Company GetfirstOrDefaulte(Expression<Func<Company, bool>> filter)
        {
           IQueryable<Company> query= _context.Companies;
           query= query.Where(filter);
           return query.FirstOrDefault();
        }

        public void remove(Company Entiny)
        {
            _context.Companies.Remove(Entiny);
            _context.SaveChanges();
        }

        public void update(Company Entiny)
        {
            _context.Companies.Update(Entiny);
            _context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<Company> Entiny)
        {
           _context.Companies.RemoveRange(Entiny);
           _context.SaveChanges();
        }
    }
}
