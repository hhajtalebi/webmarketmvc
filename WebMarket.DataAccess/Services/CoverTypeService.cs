using System.Linq.Expressions;
using WebMarket.DataAccess.Data;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class CoverTypeService:ICoverTypeService
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void add(CoverType Entity)
        {
            _db.CoverTypes.Add(Entity);
            _db.SaveChanges();
        }

        public void remove(CoverType Entity)
        {
            _db.CoverTypes.Remove(Entity);
            _db.SaveChanges();
        }

        public void update(CoverType Entity)
        {
            _db.CoverTypes.Update(Entity);
            _db.SaveChanges();
        }

        public IEnumerable<CoverType> GetAll()
        {
            IEnumerable<CoverType> Query = _db.CoverTypes;
            return Query;
        }

        public CoverType GetFirstOrDefaulte(Expression<Func<CoverType, bool>> filter)
        {
           IQueryable<CoverType> query= _db.CoverTypes;
          query= query.Where(filter);
          return query.FirstOrDefault();
        }

        public void RemoveRange(IEnumerable<CoverType> Entiny)
        {
            _db.CoverTypes.RemoveRange(Entiny);
            _db.SaveChanges();
        }
    }
}
