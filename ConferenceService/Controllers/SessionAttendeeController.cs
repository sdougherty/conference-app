using ConferenceData.Entities;
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
    public class SessionAttendeeController : ApiController
    {
        SessionAttendeeRepository repo = new SessionAttendeeRepository();

        [HttpGet]
        [Route("attendee")]
        public HttpResponseMessage GetAll(int conferenceId, int sessionId)
        {
            var attendees = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, attendees);
        }

        [HttpGet]
        [Route("attendee/{userId}")]
        public HttpResponseMessage Get(int conferenceId, int sessionId, int userId)
        {
            var attendee = repo.Get(userId);
            return Request.CreateResponse(HttpStatusCode.OK, attendee);
        }

        [HttpPost]
        [Route("attendee/{userId}")]
        public HttpResponseMessage Post(int conferenceId, int sessionId, int userId)
        {
            var attendee = repo.Create(userId, sessionId);
            return Request.CreateResponse(HttpStatusCode.OK, attendee);
        }

        [HttpPut]
        [Route("attendee/{userId}")]
        public HttpResponseMessage Put(int conferenceId, int sessionId, int userId)
        {
            var attendee = repo.Create(userId, sessionId);
            return Request.CreateResponse(HttpStatusCode.OK, attendee);
        }

        [HttpDelete]
        [Route("attendee/{userId}")]
        public HttpResponseMessage Delete(int conferenceId, int sessionId, int userId)
        {
            var result = repo.Delete(userId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}