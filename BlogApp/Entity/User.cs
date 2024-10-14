using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set;}


        //Navigation Properties 
        ICollection<Post> Posts { get; set; } = new List<Post>();
        ICollection<Comment> Comments { get; set; }=new List<Comment>();


    
    }
}