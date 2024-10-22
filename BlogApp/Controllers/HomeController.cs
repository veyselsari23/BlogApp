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
        private readonly ICommentRepository _commentRepository;

        public HomeController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }
        public IActionResult Index(string tag)
        {

            if (tag == null)
            {
                List<Post> posts = _postRepository.GetAll().Include(x => x.Tags).ToList();
                return View(posts);
            }
            else
            {

                var posts = _postRepository.GetAll().Include(x => x.Tags).Where(x => x.Tags.Any(t => t.Text == tag)).ToList();
                return View(posts);
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

        [HttpPost]
        public JsonResult AddComment(string comment)
        {

            return Json(comment);

        }

    }
}