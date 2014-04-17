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
    public class SessionController : ApiController
    {
        SessionRepository repo = new SessionRepository();

        [HttpGet]
        [Route("session")]
        public HttpResponseMessage GetAll(int conferenceId)
        {
            var sessions = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, sessions);
        }

        [HttpGet]
        [Route("session/{sessionId}")]
        public HttpResponseMessage Get(int conferenceId, int sessionId)
        {
            var session = repo.Get(sessionId);
            return Request.CreateResponse(HttpStatusCode.OK, session);
        }

        [HttpPost]
        [Route("session")]
        public HttpResponseMessage Post(int conferenceId, Session session)
        {
            session = repo.Update(session);
            return Request.CreateResponse(HttpStatusCode.OK, session);
        }

        [HttpPut]
        [Route("session")]
        public HttpResponseMessage Put(int conferenceId, Session session)
        {
            session = repo.Create(session);
            return Request.CreateResponse(HttpStatusCode.OK, session);
        }

        [HttpDelete]
        [Route("session/{sessionId}")]
        public HttpResponseMessage Delete(int conferenceId, int sessionId)
        {
            repo.Delete(sessionId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}