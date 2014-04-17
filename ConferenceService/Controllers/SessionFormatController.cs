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
    public class SessionFormatController : ApiController
    {
        SessionFormatRepository repo = new SessionFormatRepository();

        [HttpGet]
        [Route("format")]
        public HttpResponseMessage GetAll(int conferenceId)
        {
            var formats = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, formats);
        }

        [HttpGet]
        [Route("format/{formatId}")]
        public HttpResponseMessage Get(int conferenceId, int formatId)
        {
            var format = repo.Get(formatId);
            return Request.CreateResponse(HttpStatusCode.OK, format);
        }

        [HttpPost]
        [Route("format")]
        public HttpResponseMessage Post(int conferenceId, SessionFormat format)
        {
            format = repo.Update(format);
            return Request.CreateResponse(HttpStatusCode.OK, format);
        }

        [HttpPut]
        [Route("format")]
        public HttpResponseMessage Put(int conferenceId, SessionFormat format)
        {
            format = repo.Create(format);
            return Request.CreateResponse(HttpStatusCode.OK, format);
        }

        [HttpDelete]
        [Route("format/{formatId}")]
        public HttpResponseMessage Delete(int conferenceId, int formatId)
        {
            repo.Delete(formatId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}