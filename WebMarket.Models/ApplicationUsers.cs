using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebMarket.Models
{
    public class ApplicationUsers:IdentityUser
    {
        [Display(Name = "نام ونام خانوادگی")]
        public string? FullName { get; set; }
        [Display(Name = "آدرس")]
        public string? Address { get; set; }
    }
}
