using DeveloperMeetup.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Data.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task BookSeats(Booking booking, List<KeyValuePair<string, string>> seats);
    }
}
