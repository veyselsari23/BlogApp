using BlogApp.Data.Abstract;
using BlogApp.Data.Context.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete
{

    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public void GetTagsForX()
        {

        }
    }


}