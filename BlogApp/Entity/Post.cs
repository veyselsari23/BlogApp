using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }   
        public string? Content { get; set; }        
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
    

        //Navigation Properties
        public User User { get; set; }=null!;
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Tag> Tags { get; set; } = new List<Tag>();

        

    }
}