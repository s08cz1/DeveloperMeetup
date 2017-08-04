using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DeveloperMeetup.Data.Entities
{
    public class Seat : BaseEntity
    {
        public string Row { get; set; }
        public string Col { get; set; }

        public string BookedFor { get; set; }

        public Guid? BookingId { get; set; }
        public Booking Booking { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}