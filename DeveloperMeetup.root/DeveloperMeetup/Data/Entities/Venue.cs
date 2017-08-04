using DeveloperMeetup.Code.Labels.Enums;
using System.Collections.Generic;

namespace DeveloperMeetup.Data.Entities
{
    public class Venue : BaseEntity
    {
        public string Address { get; set; }
        public int Rows { get; set; }
        public LabelType RowLabelType { get; set; }
        public int Cols { get; set; }
        public LabelType ColLabelType { get; set; }
        public List<Event> Events { get; set; }
    }
}