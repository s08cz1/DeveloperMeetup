using DeveloperMeetup.Data.Entities;
using DeveloperMeetup.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Data.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DeveloperMeetupContext context) : base(context)
        {
        }
        public override IEnumerable<Event> GetAll()
        {
            //get all events with corresponding venues
            return entities.Where(x => !x.DeletedUtc.HasValue).Include(x => x.Venue).AsEnumerable();
        }

        public async override Task<Event> Get(Guid id)
        {
            //get an event with inked tables
            return await entities.Where(x => !x.DeletedUtc.HasValue).Include(x => x.Venue).Include(x => x.Seats).SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
