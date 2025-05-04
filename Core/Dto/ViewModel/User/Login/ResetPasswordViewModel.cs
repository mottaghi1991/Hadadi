﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.User.Login
{
    public class ResetPasswordViewModel
    {
        public string ActiveCode { get; set; }
        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "رمز عبور یکسان نمی باشد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string RePassword { get; set; }
    }
}
