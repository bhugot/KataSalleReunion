using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using NFluent;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specs.Steps
{
    [Binding]
    public sealed class Validation
    {
        private readonly RoomsContext _context;

        public Validation(RoomsContext context)
        {
            this._context = context;
        }
        [Then("I would get the following rooms")]
        public void ValidateRoomsAreCorrectlyReturned(Table roomsTable)
        {
            Check.That(this._context.GetReturnedRooms().Select(a => a.Name))
                .IsOnlyMadeOf(roomsTable.CreateSet<RoomViewModel>().Select(a => a.Name));
        }
    }
}
