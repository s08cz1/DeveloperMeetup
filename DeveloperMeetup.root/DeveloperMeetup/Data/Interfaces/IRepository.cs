using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> Get(Guid id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
