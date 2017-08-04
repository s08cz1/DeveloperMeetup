using DeveloperMeetup.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DeveloperMeetup.Data
{
    public class DeveloperMeetupContext : DbContext
    {
        public DeveloperMeetupContext(DbContextOptions<DeveloperMeetupContext> options)
            : base(options)
        { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Venue> Venues { get; set; }

    }

}