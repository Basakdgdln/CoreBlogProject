﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Areas.Admin.Models
{
    public class UserSıgnInViewModelArea
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz...")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz...")]
        public string password { get; set; }

    }
}
