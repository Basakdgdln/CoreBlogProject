using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.ViewComponents.Notificaton
{
    public class NotificationList : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
