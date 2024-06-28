using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Data;
using Project.DataAccess.Repostry.IRepostry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Repostry
{
    public class Repostry<T> : IRepostry<T> where T : class
    {
        private readonly AcedmixDb2Context _db;
        internal DbSet<T> dbset;

        public Repostry(AcedmixDb2Context db)
        {
            _db = db;
            this.dbset=_db.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query=dbset;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }

            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includePror in includeProperties.Split(new char[] { ',' }
                , StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includePror);

                }

            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveFromRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
