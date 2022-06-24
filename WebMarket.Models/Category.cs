using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "نام دسته اجباری است")]
        [Display(Name = "نام دسته")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required(ErrorMessage = "ترتیب نمایش اجباریست")]
        [DisplayName("ترتیب نمایش")]
        [Range(1, 100, ErrorMessage = "ترتیب نمایش باید بین 1 تا 100 باشد")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
