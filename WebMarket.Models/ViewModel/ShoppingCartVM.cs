using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Models.ViewModel
{
    public class ShoppingCartVM
    {
        public double TotalPrice { get; set; }
        public IEnumerable<ShoppingCart> ListCarts { get; set; }

        ////  [Display(Name = "تعداد")]
        ////   public int Count  { get; set; }
      
    }
}
