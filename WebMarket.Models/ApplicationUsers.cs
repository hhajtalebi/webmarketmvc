using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebMarket.Models
{
    public class ApplicationUsers:IdentityUser
    {
        [Display(Name = "نام ونام خانوادگی")]
        public string? FullName { get; set; }
        [Display(Name = "آدرس")]
        public string? Address { get; set; }

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company company { get; set; }
        [Display(Name = "تلفن")]
        public override string PhoneNumber
        {
            get{return base.PhoneNumber; }
            set { base.PhoneNumber = value; }
        }
    }
}
