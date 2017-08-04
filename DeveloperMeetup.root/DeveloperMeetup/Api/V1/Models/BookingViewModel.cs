using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Api.V1.Models
{
    public class BookingViewModel
    {
        public string EmailAddress { get; set; }
        public decimal? AmountPaid { get; set; }
        public string EventId { get; set; }
        public List<KeyValuePair<string, string>> Seats { get; set; }
    }
}
