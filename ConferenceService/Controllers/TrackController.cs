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
    public class TrackController : ApiController
    {
        TrackRepository repo = new TrackRepository();

        [HttpGet]
        [Route("track")]
        public HttpResponseMessage GetAll(int conferenceId)
        {
            var tracks = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, tracks);
        }

        [HttpGet]
        [Route("track/{trackId}")]
        public HttpResponseMessage Get(int conferenceId, int trackId)
        {
            var track = repo.Get(trackId);
            return Request.CreateResponse(HttpStatusCode.OK, track);
        }

        [HttpPost]
        [Route("track")]
        public HttpResponseMessage Post(int conferenceId, Track track)
        {
            track = repo.Update(track);
            return Request.CreateResponse(HttpStatusCode.OK, track);
        }

        [HttpPut]
        [Route("track")]
        public HttpResponseMessage Put(int conferenceId, Track track)
        {
            track = repo.Create(track);
            return Request.CreateResponse(HttpStatusCode.OK, track);
        }

        [HttpDelete]
        [Route("track/{trackId}")]
        public HttpResponseMessage Delete(int conferenceId, int trackId)
        {
            repo.Delete(trackId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}