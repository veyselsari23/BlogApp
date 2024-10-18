using Microsoft.AspNetCore.Mvc;
using BlogApp.Data.Abstract;
using BlogApp.Data.Context.EfCore;
namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {


        private readonly IPostRepository _postRepository;

        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index()
        {
            var posts = _postRepository.GetAll().ToList();
            return View(posts);

        }

    }
}