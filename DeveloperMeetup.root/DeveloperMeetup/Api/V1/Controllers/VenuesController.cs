using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeveloperMeetup.Data.Entities;
using DeveloperMeetup.Data.Interfaces;
using DeveloperMeetup.Code;
using DeveloperMeetup.Api.V1.Models;

namespace DeveloperMeetup.Api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/V{version:apiVersion}/[controller]")]
    public class VenuesController : Controller
    {
        private IRepository<Venue> _repoVenues;
        public VenuesController(IRepository<Venue> repoVenues)
        {
            _repoVenues = repoVenues;
        }

        // GET api/values
        [HttpGet]
        public HttpResult Get()
        {
            try
            {
                var venues = _repoVenues.GetAll().Select(x => new VenueViewModel() { Id = x.Id, Address = x.Address, Rows = x.Rows, Cols = x.Cols }).ToList();
                return new HttpResult() { Status = 200, Data = venues };
            }
            catch (Exception ex)
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
                var v = await _repoVenues.Get(id);

                return new HttpResult()
                {
                    Status = 200,
                    Data = new VenueViewModel()
                    {
                        Id = v.Id,
                        Address = v.Address,
                        Rows = v.Rows,
                        RowLabelType = v.RowLabelType,
                        Cols = v.Cols,
                        ColLabelType = v.ColLabelType
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
        public async Task<HttpResult> Post([FromBody]VenueViewModel vVm)
        {
            try
            {
                var entity = new Venue()
                {
                    Address = vVm.Address,
                    Rows = vVm.Rows,
                    RowLabelType = vVm.RowLabelType,
                    Cols = vVm.Cols,
                    ColLabelType = vVm.ColLabelType

                };
                await _repoVenues.Insert(entity);

                return new HttpResult() { Status = 200 };
            }
            catch (Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<HttpResult> Put(int id, [FromBody]VenueViewModel vVm)
        {
            try
            {
                var v = await _repoVenues.Get(vVm.Id);

                v.Address = vVm.Address;
                v.Rows = vVm.Rows;
                v.RowLabelType = vVm.RowLabelType;
                v.Cols = vVm.Cols;
                v.ColLabelType = vVm.ColLabelType;

                await _repoVenues.Update(v);

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
                var e = await _repoVenues.Get(id);

                await _repoVenues.Delete(e);

                return new HttpResult() { Status = 200 };
            }
            catch (Exception ex)
            {
                return new HttpResult() { Status = 500, Data = ex.Message };
            }
        }
    }
}
