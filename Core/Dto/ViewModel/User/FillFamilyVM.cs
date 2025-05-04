using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.User
{
    public class FillFamilyVM
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Family { get; set; }
        [Display(Name = "ایمیل")]
       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
