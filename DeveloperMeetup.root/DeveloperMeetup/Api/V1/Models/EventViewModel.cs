using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Api.V1.Models
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTimeUtc { get; set; }
        public DateTime EndDateTimeUtc { get; set; }
        public string VenueId { get; set; }
        public string Venue { get; set; }
    }
}
