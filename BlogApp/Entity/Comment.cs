using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }   
        public DateTime PublishedOn { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        /* Hangi Soruları sorduk ilişkiler için 
        
            1- Her bir comment bir post'a ait  olabilir 
            2- Herbir comment bir user tarafından yapılır 
            3- Comment in tag ile bir ilişkisi yoktur 
            
        
        
        */
        // Navigation Properties 
        public Post Post{ get; set; }=null!;
        public User User{ get; set; }=null!;
     
        
    }
}