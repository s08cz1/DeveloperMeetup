using DeveloperMeetup.Code.Labels;
using DeveloperMeetup.Code.Labels.Enums;
using DeveloperMeetup.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperMeetup.Code.Helpers
{
    public class VenueSeatsHelper
    {
        /// <summary>
        /// Generates seats for event based on provided amount of rows and columns (and other useful parameters)
        /// </summary>
        /// <param name="rows">Amount of rows</param>
        /// <param name="rowLabelType">Rows labeling method</param>
        /// <param name="cols">Amount of cols</param>
        /// <param name="colLabelType">Cols labeling method</param>
        /// <param name="e">Event</param>
        /// <returns>List of seats</returns>
        public static List<Seat> GenerateSeatsMatrix(int rows, LabelType rowLabelType, int cols, LabelType colLabelType, Event e)
        {
            if (rows <= 0)
                throw new Exception("Insufficient amount of rows defined.");

            if (cols <= 0)
                throw new Exception("Insufficient amount of cols defined.");

            var rowLabelGenerator = LabelFactory.GetLabelGenerator(rowLabelType);
            var colLabelGenerator = LabelFactory.GetLabelGenerator(colLabelType);

            var seats = new List<Seat>();

            for(var i = 1; i <= rows; i++)
            {
                for (var j = 1; j <= cols; j++)
                {
                    seats.Add(new Seat()
                    {
                        Row = rowLabelGenerator.GetLabel(i),
                        Col = colLabelGenerator.GetLabel(j),
                        Event = e
                    });
                }
            }
            return seats;
        }
    }
}
