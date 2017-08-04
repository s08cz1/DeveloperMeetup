using DeveloperMeetup.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DeveloperMeetupContext context;
        protected DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(DeveloperMeetupContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable().Where(x => !x.DeletedUtc.HasValue);
        }

        public async virtual Task<T> Get(Guid id)
        {
            return await entities.Where(x => !x.DeletedUtc.HasValue).SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.DeletedUtc = DateTime.UtcNow;
            await context.SaveChangesAsync();
        }

    }
}
