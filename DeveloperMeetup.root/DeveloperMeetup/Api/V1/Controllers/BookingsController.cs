using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperMeetup.Data.Interfaces;
using DeveloperMeetup.Data.Entities;
using DeveloperMeetup.Code;
using DeveloperMeetup.Api.V1.Models;

namespace DeveloperMeetup.Api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/V{version:apiVersion}/[controller]")]
    public class BookingsController : Controller
    {
        private IRepository<Booking> _repoBookings;
        private ISeatRepository _repoSeats;
        private IEventRepository _repoEvents;
        private IRepository<Venue> _repoVenues;
        public BookingsController(IEventRepository repoEvents, ISeatRepository repoSeats, IRepository<Venue> repoVenues, IRepository<Booking> repoBookings)
        {
            _repoEvents = repoEvents;
            _repoSeats = repoSeats;
            _repoVenues = repoVenues;
            _repoBookings = repoBookings;
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResult> Post([FromBody]BookingViewModel bVm)
        {
            try
            {
                //validate if everythng is fine

                var e = await _repoEvents.Get(Guid.Parse(bVm.EventId));

                if (e == null)
                    return new HttpResult() { Status = 1000, Data = "Event could not be found." };

                if (e.FeePerSeat.HasValue && (bVm.AmountPaid ?? 0) != bVm.Seats.Count * e.FeePerSeat.Value)
                    return new HttpResult() { Status = 1001, Data = "Invalid payment amount." };

                var seatsCount = bVm.Seats.Count;

                if (bVm.Seats.Count > 4)
                    return new HttpResult() { Status = 1002, Data = "You can book no more than 4 seats at a time." };

                if (string.IsNullOrWhiteSpace(bVm.EmailAddress))
                    return new HttpResult() { Status = 1003, Data = "Please provide your email address." };

                if (bVm.Seats.Any(x => string.IsNullOrWhiteSpace(x.Value)))
                    return new HttpResult() { Status = 1004, Data = "Please provide email addresses for all participants." };

                if (bVm.Seats.GroupBy(x => x.Value, x => x.Key).Any(x => x.Count() > 1))
                    return new HttpResult() { Status = 1005, Data = "Please provide unique email addresses for all requested seats." };

                var b = new Booking()
                {
                    DateBookedUtc = DateTime.UtcNow,
                    EmailAddress = bVm.EmailAddress,
                    AmountPaid = bVm.AmountPaid,
                    EventId = Guid.Parse(bVm.EventId)
                };

                await _repoSeats.BookSeats(b, bVm.Seats);

                return new HttpResult() { Status = 200 };
            }
            catch (Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }
    }
}
