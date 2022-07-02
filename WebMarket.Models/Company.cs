using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace WebMarket.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "آدرس")]
        public string? StreetAddress { get; set; }
        [Display(Name = "تلفن")]
        public string? PhonNumber { get; set; }
        [Display(Name = "شهر")]
        public string? City { get; set; }

    }
}
