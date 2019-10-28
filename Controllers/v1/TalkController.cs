using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DashModule.EventOrgranizer.Model;
using DashModule.EventOrgranizer.Manager;
using Microsoft.AspNetCore.Authorization;

namespace DashModule.EventOrgranizer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TalkController : ControllerBase
    {
        private readonly ILogger<TalkController> _logger;

        public TalkController(ILogger<TalkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Talk>> Get()
        {
            var talkManager = new TalkManager(_logger);

            return await talkManager.GetTalks();
        }

        [HttpGet, Route("{id}")]
        public async Task<Talk> Get(Guid talkId)
        {
            var talkManager = new TalkManager(_logger);

            return await talkManager.GetTalk(talkId);
        }

        [HttpGet, Route("{id}/participants")]
        public Task<IEnumerable<User>> GetParticipants(Guid talkId) => throw new NotImplementedException();

        [HttpPost]
        [Authorize]
        public void Create([FromBody] Talk talk)
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("{id}")]
        [Authorize]
        public void Update([FromBody] Talk talk)
        {
            throw new NotImplementedException();
        }

        [HttpDelete, Route("{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            //Check Token validity

            //Check guid is valid

            var talkManager = new TalkManager(_logger);

            talkManager.DeleteTalk(id);
        }
    }
}
