using DeveloperMeetup.Code.Labels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Api.V1.Models
{
    public class VenueViewModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int Rows { get; set; }
        public LabelType RowLabelType { get; set; }
        public int Cols { get; set; }
        public LabelType ColLabelType { get; set; }
        public int Seats => Rows* Cols;
    }
}
