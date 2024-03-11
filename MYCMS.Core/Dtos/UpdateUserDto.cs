using Microsoft.AspNetCore.Http;
using MYCMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Core.Dtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني ")]
        public string Email { get; set; }
        [Required]
        [Phone]
        [Display(Name = "رقم الجوال ")]
        public string PhoneNumber { get; set; }
        [Display(Name = "الصورة")]
        public IFormFile ImageUrl { get; set; }
        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required]
        [Display(Name = "نوع المستخدم")]
        public UserType UserType { get; set; }
    }
}
