using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Interfaces
{
    public interface  InterfaceBase<T> where T : class, new()
    {

        public void Save(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public IEnumerable<T> GetAll();
        public T GetById(Guid id);
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        public bool Exists(Expression<Func<T, bool>> expression);

        public T GetByIdWithIncludes(Guid id, params Expression<Func<T, object>>[] includes);
    }
}
