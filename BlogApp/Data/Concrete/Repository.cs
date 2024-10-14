using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Data.Context.EfCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(T entity)
        {
            if (entity != null)
            {

                _dataContext.Set<T>().Add(entity);
                _dataContext.SaveChanges();

            }
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {

                _dataContext.Set<T>().Remove(entity);
                _dataContext.SaveChanges();

            }
        }

        public ICollection<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var entity = _dataContext.Set<T>().Find(id);
            return entity;
        }

        public void Update(T entity)
        {
            if (entity != null)
            {


                _dataContext.Set<T>().Update(entity);
                _dataContext.SaveChanges();

            }
        }
    }
}