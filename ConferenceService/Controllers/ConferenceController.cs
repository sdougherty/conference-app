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
    [RoutePrefix("api/v1")]
    public class ConferenceController : ApiController
    {
        ConferenceRepository repo = new ConferenceRepository();

        [HttpGet]
        [Route("conference")]
        public HttpResponseMessage GetAll()
        {
            var conferences = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, conferences);
        }

        [HttpGet]
        [Route("conference/{conferenceId}")]
        public HttpResponseMessage Get(int conferenceId)
        {
            var conference = repo.Get(conferenceId);
            return Request.CreateResponse(HttpStatusCode.OK, conference);
        }

        [HttpPost]
        [Route("conference")]
        public HttpResponseMessage Post(Conference conference)
        {
            conference = repo.Update(conference);
            return Request.CreateResponse(HttpStatusCode.OK, conference);
        }

        [HttpPut]
        [Route("conference")]
        public HttpResponseMessage Put(Conference conference)
        {
            conference = repo.Create(conference);
            return Request.CreateResponse(HttpStatusCode.OK, conference);
        }

        [HttpDelete]
        [Route("conference/{conferenceId}")]
        public HttpResponseMessage Delete(int conferenceId)
        {
            repo.Delete(conferenceId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("conference/{conferenceId}/speakers")]
        public HttpResponseMessage GetSpeakers(int conferenceId)
        {
            var speakerRepo = new SessionSpeakerRepository();
            var speakers = speakerRepo.GetSpeakerRoster(conferenceId);

            return Request.CreateResponse(HttpStatusCode.OK, speakers);
        }
    }
}