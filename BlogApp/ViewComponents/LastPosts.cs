using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class LastPosts : ViewComponent
    {


        private readonly IPostRepository _postRepository;

        public LastPosts(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public  IViewComponentResult Invoke(){

            List<Post> result= _postRepository.GetAll().ToList();

            return  View(result);
        }

    }
}