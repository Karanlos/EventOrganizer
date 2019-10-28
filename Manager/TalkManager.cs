using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrgranizer.Controllers;
using DashModule.EventOrgranizer.Model;
using Microsoft.Extensions.Logging;

namespace DashModule.EventOrgranizer.Manager
{

    public class TalkManager : ITalkManager
    {
        private ILogger Log { get; set; }

        public TalkManager(ILogger log)
        {
            Log = log;
        }

        public Task<Guid> CreateTalk(string title, string desciption, Guid talker)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTalk(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Talk> GetTalk(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Talk>> GetTalks()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTalk(Guid talkId, string title, string description, Guid talker)
        {
            throw new NotImplementedException();
        }
    }

}