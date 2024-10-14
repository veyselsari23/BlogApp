using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int Text { get; set; }   
        public DateTime PublishedOn { get; set; }

        public int PostId { get; set; }
        public int UserId { get; set; }

        // Navigation Properties 
        public Post Post{ get; set; }=null!;
        public User User{ get; set; }=null!;
     
        
    }
}