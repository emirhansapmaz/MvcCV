using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCV.Models;
namespace MvcCV.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvContext context = new DbCvContext();
        public List<T> List()
        {
            return context.Set<T>().ToList();
        }
        public void Insert(T p)
        {
            context.Set<T>().Add(p);
            context.SaveChanges();
        }
        public void delete(T p)
        {
            context.Set<T>().Remove(p);
            context.SaveChanges();
        }
        public T TGetir(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Update(T p)
        {
            context.SaveChanges();
        }
    }
}
