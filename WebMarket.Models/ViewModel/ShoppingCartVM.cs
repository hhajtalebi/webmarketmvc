using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Models.ViewModel
{
    public class ShoppingCartVM
    {
     public  Product Product { get; set; }
     [Display(Name = "تعداد")]
     public int Count  { get; set; }
    }
}
