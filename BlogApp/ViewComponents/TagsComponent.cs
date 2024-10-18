using Microsoft.AspNetCore.Mvc;


namespace BlogApp.ViewComponents
{



    public class TagsComponent : ViewComponent
    {


       

        public IViewComponentResult Index()
        {

            return View();

        }


    }


}