using System.Linq;
using System.Net;
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

        [Then("the result should be ok")]
        public void ResponseIsOk()
        {
            Check.That(this._context.ResponseStatusCode).IsEqualTo(HttpStatusCode.OK);
        }

        [Then("the result should be a conflict")]
        public void ResponseIsConflict()
        {
            Check.That(this._context.ResponseStatusCode).IsEqualTo(HttpStatusCode.Conflict);
        }

        [Then("the responses should contains following slots:")]
        public void AvailableSlots(Table slots)
        {
            Check.That(this._context.AvailableSlots()).IsOnlyMadeOf(slots.CreateSet<SlotViewModel>());
        }
    }
}