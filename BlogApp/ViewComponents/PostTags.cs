using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents
{
    public class PostTags:ViewComponent
    {

            private  ITagRepository _tagRepository;

            public PostTags(ITagRepository tagRepository)
            {
                _tagRepository=tagRepository;
            }

            public IViewComponentResult Invoke(){

                var datas =_tagRepository.GetAll().ToList();

                return View(datas);
            }

    }
}