using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Gen2_MVCRepository.AccesoDatos.Data.Repository
{
    
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext ctx;
        public DbSet<T> dbset;

        public Repository(DbContext _ctx0)
        {
            ctx = _ctx0;
            dbset = ctx.Set<T>();
        }
        
        public void Add(T registro)
        {
            dbset.Add(registro);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(T registro)
        {
            dbset.Remove(registro);
        }

        public void Remove(int id)
        {
            dbset.Remove(dbset.Find(id));
        }
    }
}
