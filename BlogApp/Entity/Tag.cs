using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Tag
    {
        public int TagId { get; set; }
        public string? Text { get; set; }
        public string? url{get;set;}

        /*
            Hangi soruları sorduk 
            1- Her tag birden fazla post da olabiliru
            2- Tag in user ve comment ile bir ilişkisi yoktur

        */

        // Navigation Properties
        public List<Post> Posts { get; set; } = new List<Post>();


    }
}