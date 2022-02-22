using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gen2_MVCRepository.AccesoDatos.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);
        void Add(T registro);
        void Remove(T registro);
        void Remove(int id);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
    }
}
