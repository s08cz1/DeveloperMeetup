using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Api.V1.Models
{
    public class SeatViewModel
    {
        public Guid Id { get; set; }
        public string Row { get; set; }
        public string Col { get; set; }
        public string BookedFor { get; set; }
    }
}
