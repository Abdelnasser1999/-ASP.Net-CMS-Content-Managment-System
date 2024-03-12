using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYCMS.Core.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [Display(Name = "اسم التصنيف")]
        public string Name { get; set; }
    }
}
