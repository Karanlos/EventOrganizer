using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrganizer.Controllers;
using DashModule.EventOrganizer.Model;
using Microsoft.Extensions.Logging;

namespace DashModule.EventOrganizer.Manager
{

    public class UserManager : IUserManager
    {
        private ILogger Log { get; set; }

        public UserManager(ILogger log)
        {
            Log = log;
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateUser(string firstName, string lastName, string email, string phoneNumber, Address address)
        {
            //TODO: User and create address and persist
            throw new NotImplementedException();
        }

        public Task UpdateUser(Guid userId, string firstName, string lastName, string email, string phoneNumber, Address address)
        {
            //TODO: Update user, check if user already has an address, update or create depending on if it already has and persist
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }

}