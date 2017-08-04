using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DeveloperMeetup.Data.Entities
{
    public class Booking : BaseEntity
    {
        public DateTime DateBookedUtc { get; set; }
        public string EmailAddress { get; set; }

        public decimal? AmountPaid { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public List<Seat> Seats { get; set; }
    }
}