using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Data.Context.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete
{
    public class CommentRepository:Repository<Comment>, ICommentRepository
    {

        public CommentRepository(DataContext dataContext):base(dataContext)
        {
          
        }

      
        
    }
}