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
    public class UserController : ApiController
    {
        UserRepository repo = new UserRepository();

        [HttpGet] 
        [Route("user")]
        public HttpResponseMessage GetAll()
        {
            var users = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public HttpResponseMessage Get(int userId)
        {
            var user = repo.Get(userId);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("user")]
        public HttpResponseMessage Post(User user)
        {
            user = repo.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPut]
        [Route("user")]
        public HttpResponseMessage Put(User user)
        {
            user = repo.Create(user);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpDelete]
        [Route("user/{userId}")]
        public HttpResponseMessage Delete(int userId)
        {
            repo.Delete(userId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}