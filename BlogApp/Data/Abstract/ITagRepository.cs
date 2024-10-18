using BlogApp.Entity;

namespace BlogApp.Data.Abstract{

    public interface ITagRepository:IRepository<Tag>
    {

            void GetTagsForX();

    }
}