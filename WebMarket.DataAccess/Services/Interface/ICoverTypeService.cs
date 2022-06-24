using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICoverTypeService
    {
        public void add(CoverType Entity);
        public void remove(CoverType Entity);
        public void update(CoverType Entity);
        public IEnumerable<CoverType> GetAll();
        public CoverType GetFirstOrDefaulte(Expression<Func<CoverType, bool>> filter);
        public void RemoveRange(IEnumerable<CoverType> Entiny);
       

    }
}
