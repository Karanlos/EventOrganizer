using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrganizer.Model;

namespace DashModule.EventOrganizer.Database
{
    public class MockDbContext : IDbContext
    {
        public Task<Event> GetEvent(Guid id)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Address = new Address()
                {
                    City = "Børkop",
                    Country = "Denmark",
                    PostalCode = "7080",
                    State = "Vejle",
                    Street = "Hovedgade 1"
                },
                FirstName = "Erik",
                LastName = "S",
                Email = "email@email.email",
                PhoneNumber = "123432234"
            };
            var participants = new List<User>();

            participants.Add(user);

            var talks = new List<Talk>();

            talks.Add(new Talk()
            {
                Presenter = user,
                StartTime = new DateTime(2019, 10, 30),
            });

            return Task.FromResult(new Event()
            {
                Id = Guid.NewGuid(),
                Name = "Beer Convention",
                Description = "Awesome Beer convention! Several speakers!",
                StartDate = new DateTime(2019, 10, 30),
                EndDate = new DateTime(2019, 10, 31),
                Participants = participants,
                Talks = talks,
                Venue = new Venue()
                {
                    Address = new Address()
                    {
                        City = "Billund",
                        Country = "Denmark",
                        PostalCode = "7190",
                        State = "Vejle",
                        Street = "Hovedgade 1"
                    },
                }
            });
        }
    }
}