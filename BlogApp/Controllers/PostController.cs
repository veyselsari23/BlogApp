using BlogApp.Data.Abstract;
using BlogApp.Data.Context.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers{



    public class PostController:Controller{

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {   
            _postRepository=postRepository;
        }


        public ActionResult Index(){

           var posts= _postRepository.GetAll().ToList();
            return View(posts);
        }

        


    }


}