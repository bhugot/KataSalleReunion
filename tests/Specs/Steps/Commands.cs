using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public sealed class Commands
    {
        private readonly RoomsContext _context;

        public Commands(RoomsContext context)
        {
            this._context = context;
        }

        [When("I Ask for rooms")]
        public void WhenIAskApiForRooms()
        {
            this._context.CallRooms().Wait();
        }
    }
}
