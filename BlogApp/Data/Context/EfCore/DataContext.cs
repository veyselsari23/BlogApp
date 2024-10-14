using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Context.EfCore
{


    public class DataContext : DbContext
    {


        public DataContext(DbContextOptions options) : base(options)
        {


        }
        
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();

    }

}