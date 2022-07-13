using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebMarket.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUsers ApplicationUsers { get; set; }

        //تاریخ ایجاد
        public DateTime OrderDateTime { get; set; }= DateTime.Now;

        //تارسخ ارسال
        public DateTime shippingDate { get; set; }

        //جمع سفارشات
        public Double OrderTotal { get; set; }

        //وضعیت سفارش
        public string OrderStasus { get; set; }


        //وضعیت پرداخت وضعیت  پرداخت شد //پرداخت نشد
        public string? PaymentStasus { get; set; }

        //شماره حمل و نقل
        public string? TrackingNumber { get; set; }

        //حامل  // با چه چیزی ارسال شده است
        public string? Carrier { get; set; }

        //تاریخ پرداخت
        public DateTime PaymentDate { get; set; }


        //تاریخ سر رسید پرداخت
        public DateTime PaymentDueDate { get; set; }

        //ایدی جلسه
        public string? SetssionId { get; set; }

        //مقصد پرداخت
        public string? PaymetnIntentId { get; set; }

        //شماره تلفن
        [Required]
        public string PhoneNumber { get; set; }


        //آدرس
        [Required]
        public string StreetAddress { get; set; }


        //شهر
        [Required]
        public string City { get; set; }

        //خیابان منطقه
        [Required]
        public string State { get; set; }

        // نام مشتری
        [Required]
        public string Name { get; set; }

    }
}
