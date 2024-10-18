using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents
{
    public class Comments:ViewComponent
    {



                

        public IViewComponentResult Invoke(){

            return View();
        }
        
    }
}