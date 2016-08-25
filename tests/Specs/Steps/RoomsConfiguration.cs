using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Models;
using Domain;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specs.Steps
{
    [Binding]
    public sealed class RoomsConfiguration
    {
        private readonly RoomsContext _context;

        public RoomsConfiguration(RoomsContext context)
        {
            this._context = context;
        }
        [Given("I have all the following rooms:")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(Table roomsTable)
        {
            this._context.InitializeRooms(roomsTable.CreateSet<RoomViewModel>().Select(a => new Room(a.Name)));
        }
    }
}
