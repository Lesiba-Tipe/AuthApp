using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Data;

namespace AuthApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AuthDBContext context;
        internal DbSet<T> dbSet;
        public GenericRepository(AuthDBContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
            //this.logger = logger;
        }

        public virtual async  Task<T> Insert(T entity)
        {
            var results = await dbSet.AddAsync(entity);

            return results.Entity;
        }
        public virtual async Task<T> FindById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task Update(T entity)
        {            
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Delete(string id)
        {
            var entity = await dbSet.FindAsync(id);
            context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
