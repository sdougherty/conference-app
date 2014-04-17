using ConferenceData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConferenceService.Controllers
{
    [RoutePrefix("api/v1/conference/{conferenceId}/session/{sessionId}")]
    public class SessionSpeakerController : ApiController
    {
        SessionSpeakerRepository repo = new SessionSpeakerRepository();

        [HttpGet]
        [Route("speaker")]
        public HttpResponseMessage GetAll(int conferenceId, int sessionId)
        {
            var speakers = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, speakers);
        }

        [HttpGet]
        [Route("speaker/{userId}")]
        public HttpResponseMessage Get(int conferenceId, int sessionId, int userId)
        {
            var speaker = repo.Get(userId);
            return Request.CreateResponse(HttpStatusCode.OK, speaker);
        }

        [HttpPost]
        [Route("speaker/{userId}")]
        public HttpResponseMessage Post(int conferenceId, int sessionId, int userId)
        {
            var speaker = repo.Create(userId, sessionId);
            return Request.CreateResponse(HttpStatusCode.OK, speaker);
        }

        [HttpPut]
        [Route("speaker/{userId}")]
        public HttpResponseMessage Put(int conferenceId, int sessionId, int userId)
        {
            var speaker = repo.Create(userId, sessionId);
            return Request.CreateResponse(HttpStatusCode.OK, speaker);
        }

        [HttpDelete]
        [Route("speaker/{userId}")]
        public HttpResponseMessage Delete(int conferenceId, int sessionId, int userId)
        {
            var result = repo.Delete(userId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}