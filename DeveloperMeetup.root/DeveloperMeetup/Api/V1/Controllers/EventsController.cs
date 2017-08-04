using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperMeetup.Data.Interfaces;
using DeveloperMeetup.Data.Entities;
using DeveloperMeetup.Api.V1.Models;
using DeveloperMeetup.Code.Helpers;
using DeveloperMeetup.Code;

namespace DeveloperMeetup.Api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/V{version:apiVersion}/[controller]")]
    public class EventsController : Controller
    {
        private IEventRepository _repoEvents;
        private IRepository<Venue> _repoVenues;
        public EventsController(IEventRepository repoEvents, IRepository<Venue> repoVenues)
        {
            _repoEvents = repoEvents;
            _repoVenues = repoVenues;
        }

        // GET api/values
        [HttpGet]
        public HttpResult Get()
        {
            try
            {
                var events = _repoEvents.GetAll().Select(x => new EventViewModel { Id = x.Id, Name = x.Name, Venue = x.Venue.Address, VenueId = x.Venue.Id.ToString(), StartDateTimeUtc = x.StartDateTimeUtc, EndDateTimeUtc = x.EndDateTimeUtc });
                return new HttpResult() { Status = 200, Data = events };
            }
            catch(Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<HttpResult> Get(Guid id)
        {
            try
            {
                var e = await _repoEvents.Get(id);

                return new HttpResult() { Status = 200, Data = new
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Venue = e.Venue.Address,
                        StartDateTimeUtc = e.StartDateTimeUtc,
                        EndDateTimeUtc = e.EndDateTimeUtc,
                        Seats = e.Seats
                    }
                };
            }
            catch (Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<HttpResult> Post([FromBody]EventViewModel eVm)
        {
            try
            {
                var venue = await _repoVenues.Get(Guid.Parse(eVm.VenueId));

                var entity = new Event()
                {
                    Name = eVm.Name,
                    StartDateTimeUtc = eVm.StartDateTimeUtc,
                    EndDateTimeUtc = eVm.EndDateTimeUtc,
                    VenueId = Guid.Parse(eVm.VenueId)
                };

                //based on the venue generate seats for the event
                entity.Seats = VenueSeatsHelper.GenerateSeatsMatrix(venue.Rows, venue.RowLabelType, venue.Cols, venue.ColLabelType, entity);

                await _repoEvents.Insert(entity);

                return new HttpResult() { Status = 200 };
            }
            catch(Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<HttpResult> Put(int id, [FromBody]EventViewModel eVm)
        {
            try
            {
                var e = await _repoEvents.Get(eVm.Id);

                e.Name = eVm.Name;
                e.StartDateTimeUtc = eVm.StartDateTimeUtc;
                e.EndDateTimeUtc = eVm.EndDateTimeUtc;

                await _repoEvents.Update(e);

                return new HttpResult() { Status = 200 };
            }
            catch (Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<HttpResult> Delete(Guid id)
        {
            try
            {
                var e = await _repoEvents.Get(id);

                await _repoEvents.Delete(e);

                return new HttpResult() { Status = 200 };
            }
            catch (Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }
    }
}
