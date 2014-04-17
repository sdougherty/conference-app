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
    [RoutePrefix("api/v1/conference/{conferenceId}")]
    public class ConferenceAttendeeController : ApiController
    {
        ConferenceAttendeeRepository repo = new ConferenceAttendeeRepository();

        [HttpGet]
        [Route("attendee")]
        public HttpResponseMessage GetAll(int conferenceId)
        {
            var attendees = repo.GetAll(conferenceId);
            return Request.CreateResponse(HttpStatusCode.OK, attendees);
        }

        [HttpGet]
        [Route("attendee/{userId}")]
        public HttpResponseMessage Get(int conferenceId, int userId)
        {
            var attendee = repo.Get(conferenceId, userId);
            return Request.CreateResponse(HttpStatusCode.OK, attendee);
        }

        [HttpPut]
        [Route("attendee/{userId}")]
        public HttpResponseMessage Put(int conferenceId, int userId)
        {
            var attendee = repo.Create(conferenceId, userId);
            return Request.CreateResponse(HttpStatusCode.OK, attendee);
        }

        [HttpDelete]
        [Route("attendee/{userId}")]
        public HttpResponseMessage Delete(int conferenceId, int userId)
        {
            repo.Delete(conferenceId, userId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}