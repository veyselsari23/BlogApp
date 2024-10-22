using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Context.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICommentRepository : IRepository<Comment>
    {
      
    }
}