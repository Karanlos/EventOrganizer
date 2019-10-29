using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrganizer.Model;
using Microsoft.Extensions.Logging;

namespace DashModule.EventOrganizer.Manager
{

    public interface ITalkManager
    {
        Task<IEnumerable<Talk>> GetTalks();
        Task<Talk> GetTalk(Guid id);
        Task<Guid> CreateTalk(string title, string desciption, Guid talker);
        Task UpdateTalk(Guid talkId, string title, string description, Guid talker);
        Task DeleteTalk(Guid id);
    }

}