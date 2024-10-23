using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class Comments : ViewComponent
    {


        private readonly IPostRepository _postRepository;

        public Comments(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }



        public IViewComponentResult Invoke(int id)
        {

            Post? result = _postRepository.GetAll()
            .Include(x => x.Comments)
            .ThenInclude(x=> x.User)
            .FirstOrDefault(x => x.PostId == id);
            return View(result.Comments);
        }

    }
}