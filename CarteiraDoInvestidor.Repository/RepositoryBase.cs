using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository
{
    //classe abstrata
    public abstract class RepositoryBase<T> where T : class, new()
    {
        protected CarteiraDoInvestidorContext Context { get; set; }

        public RepositoryBase(CarteiraDoInvestidorContext context)
        {
            Context = context;
        }

        public void Save(T entity)
        {
            this.Context.Add(entity);
            this.Context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.Context.Update(entity);
            this.Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            this.Context.Remove(entity);
            this.Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this.Context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return this.Context.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return this.Find(expression).Any();
        }

        public T GetByIdWithIncludes(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var query = Context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null && idProperty.PropertyType == typeof(Guid))
            {
                query = query.Where(x => (Guid)idProperty.GetValue(x) == id);
                return query.FirstOrDefault();
            }

            throw new InvalidOperationException($"A entidade genérica '{typeof(T).Name}' não possui uma propriedade 'Id' do tipo 'Guid'.");
        }

    }
}
