using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrgranizer.Model;
using Microsoft.Extensions.Logging;

namespace DashModule.EventOrgranizer.Manager
{

    public interface IUserManager
    {
        Task<User> GetUser(Guid id);
        Task<Guid> CreateUser(string firstName, string lastName, string email, string phoneNumber, Address address);
        Task UpdateUser(Guid userId, string firstName, string lastName, string email, string phoneNumber, Address address);
        Task DeleteUser(Guid userId);
    }

}