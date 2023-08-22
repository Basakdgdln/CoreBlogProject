using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Models
{
    public class UserUpdateViewModel
    {
        public int id { get; set; }
        public string namesurname { get; set; }
        public string mail { get; set; }
        public string imageurl { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
