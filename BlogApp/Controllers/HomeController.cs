using Microsoft.AspNetCore.Mvc;
using BlogApp.Data.Abstract;
using BlogApp.Data.Context.EfCore;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using BlogApp.ViewComponents;
namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {


        private readonly IPostRepository _postRepository;

        public HomeController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index(string tag)
        {

            if(tag==null){
            List<Post> posts = _postRepository.GetAll().Include(x => x.Tags).ToList();
            return View(posts);
            }
            else
            {
                var ps=_postRepository.GetAll().Include(x=> x.Tags).ToList();
                var posts=ps.Where(x=> x.Tags.Any(t=> t.url==tag));
                return View(posts.ToList());
            }

        }

        public async Task<IActionResult> Details(string url)
        {

            var result = await _postRepository.GetAll().Include(x => x.Tags).FirstOrDefaultAsync(x => x.Url == url);

            if (result != null)
                return View(result);
            else
                return NotFound();
        }

    }
}