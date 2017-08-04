using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DeveloperMeetup.Data.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDateTimeUtc { get; set; }
        public DateTime EndDateTimeUtc { get; set; }

        public decimal? FeePerSeat { get; set; }

        public Guid VenueId { get; set; }
        public Venue Venue { get; set; }

        public List<Seat> Seats { get; set; }
    }
}