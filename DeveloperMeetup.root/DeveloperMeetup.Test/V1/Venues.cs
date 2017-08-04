using System;
using NUnit;
using NSubstitute;
using NUnit.Framework;
using DeveloperMeetup.Data.Entities;
using DeveloperMeetup.Data.Interfaces;
using DeveloperMeetup.Api.V1.Controllers;
using System.Collections;
using System.Collections.Generic;
using DeveloperMeetup.Api.V1.Models;
using System.Threading.Tasks;

namespace DeveloperMeetup.Test.V1
{
    public class VenuesTests
    {
        [Test]
        public void Get_All_Venues()
        {
            IRepository<Venue> venueRepository = Substitute.For<IRepository<Venue>>();
            venueRepository.GetAll().Returns(new List<Venue>() { new Venue() { Id = Guid.NewGuid(), Address = "House Name, Street, City, PostCode", Rows = 10, RowLabelType = Code.Labels.Enums.LabelType.Alfabetic, Cols = 10, ColLabelType = Code.Labels.Enums.LabelType.Numeric } });

            var controller = new VenuesController(venueRepository);

            var result = controller.Get();

            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(((List<VenueViewModel>)result.Data).Count, 1);
        }
        [Test]
        public async Task Get_Specific_Venue()
        {
            IRepository<Venue> customerRepository = Substitute.For<IRepository<Venue>>();
            customerRepository.Get(Arg.Any<Guid>()).Returns(new Venue() { Id = Guid.NewGuid(), Address = "House Name, Street, City, PostCode", Rows = 10, RowLabelType = Code.Labels.Enums.LabelType.Alfabetic, Cols = 10, ColLabelType = Code.Labels.Enums.LabelType.Numeric });

            var controller = new VenuesController(customerRepository);

            var result = await controller.Get(Arg.Any<Guid>());

            Assert.AreEqual(result.Status, 200);
            Assert.AreEqual(((VenueViewModel)result.Data).Seats, 100);
        }
    }
}
