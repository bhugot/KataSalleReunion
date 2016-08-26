using System;
using System.Net;
using NFluent;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [When("I book the room (.*) as (.*) for the (.*) from (.*) to (.*)")]
        public void WhenIBookARoom(string room, string user, DateTime date, string start, string end)
        {
            var startTime = RegistrationTest.GetDate(date, start);
            var endTime = RegistrationTest.GetDate(date, end);

            this._context.BookRoom(room, user, startTime, endTime).Wait();
        }

        [When("I unbook the room (.*) as (.*) for the (.*) at (.*)")]
        public void WhenIBookARoom(string room, string user, DateTime date, string start)
        {
            var startTime = RegistrationTest.GetDate(date, start);

            this._context.UnbookRoom(room, user, startTime).Wait();
        }

        [Given("their is previous registrations:")]
        public void GivenMultipleRegistration(Table table)
        {
            var registrations = table.CreateSet<RegistrationTest>();

            foreach (var registration in registrations)
            {
                this._context.BookRoom(registration.Room, registration.User, registration.GetStart(),
                    registration.GetEnd()).Wait();
                Check.That(this._context.ResponseStatusCode).IsEqualTo(HttpStatusCode.OK);
            }
        }
    }

    public class RegistrationTest
    {
        public string Room { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Start { get; set; }

        public string End { get; set; }

        public DateTime GetStart()
        {
            return GetDate(this.Date, this.Start);
        }

        public DateTime GetEnd()
        {
            return GetDate(this.Date, this.End);
        }

        internal static DateTime GetDate(DateTime date, string hours)
        {
            int time;
            if (hours.EndsWith("pm"))
            {
                time = int.Parse(hours.Replace("pm", string.Empty).Trim());
                time += 12;
            }
            else
            {
                time = int.Parse(hours.Replace("am", string.Empty).Trim());
            }
            return date.Date.AddHours(time);
        }
    }
}