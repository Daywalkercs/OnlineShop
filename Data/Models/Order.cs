using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter your firstname")]
        [StringLength(50)]
        [Required(ErrorMessage = "This field is required")]
        public required string FirstName { get; set; }

        [Display(Name = "Enter your surname")]
        [StringLength(50)]
        [Required(ErrorMessage = "This field is required")]
        public required string SurName { get; set; }

        [Display(Name = "Enter your address")]
        [StringLength(50)]
        [Required(ErrorMessage = "This field is required")]
        public required string Address { get; set; }

        [Display(Name = "Enter your phone")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "This field is required")]
        public required string Phone { get; set; }

        [Display(Name = "Enter your email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This field is required")]
        public required string Email { get; set; }

        [BindNever]
        [ScaffoldColumn (false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
      
    }
}
