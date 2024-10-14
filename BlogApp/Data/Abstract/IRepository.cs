namespace BlogApp.Data.Abstract{




    public interface IRepository<T> where T : class
    {
            void Add(T entity);
            void Update(T entity);
            void Delete(T entity);
            ICollection<T> GetAll();
            T GetById(int id);        
    }
}