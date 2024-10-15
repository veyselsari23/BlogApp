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
        public string? PostContent { get; set; }        
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    
        /*
            hangi Sorularla oluşturduk
            1- Her post bir kullanıcı tarafından yapılmıştır
            2- Her Posta Ait birden fazla comment vardır 
            3- Her post un birden fazla tag'ı olabilir

        */

        //Navigation Properties
        public User User { get; set; }=null!;
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Tag> Tags { get; set; } = new List<Tag>();

        

    }
}