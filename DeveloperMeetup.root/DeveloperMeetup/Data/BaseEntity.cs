using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Data
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }
}
