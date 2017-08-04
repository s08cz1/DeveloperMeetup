using DeveloperMeetup.Data.Entities;
using DeveloperMeetup.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Data.Repositories
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
        public SeatRepository(DeveloperMeetupContext context) : base(context)
        {
        }
        public async Task BookSeats(Booking booking, List<KeyValuePair<string, string>> seats)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                foreach(var seat in seats)
                {
                    var s = await Get(Guid.Parse(seat.Key));

                    //seat belongs to a different event?
                    if (booking.EventId != s.EventId)
                        throw new Exception($"Seat {s.Row}{s.Col} can't be booked at this moment.");

                    //already booked? that's a no go!
                    if (!string.IsNullOrWhiteSpace(s.BookedFor))
                        throw new Exception($"Seat {s.Row}{s.Col} is already booked.");

                    s.BookedFor = seat.Value;
                    s.Booking = booking;

                    await Update(s);
                }

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();
            }
        }
    }
}
