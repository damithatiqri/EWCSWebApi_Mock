using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWCSWebApi_Mock.Controllers
{
    public class PicklistsController : ApiController
    {
        private static readonly List<PickRequest> Requests = new List<PickRequest>();

        // GET: api/Picklists
        public IEnumerable<PickRequest> Get()
        {
            return Requests;
        }

        // GET: api/Picklists/5?lineId=10
        public PickRequest Get(string id, int lineId)
        {
            return Requests.First(a => a.Id == id && a.LineId == lineId);
        }

        // POST: api/Picklists
        public void Post([FromBody]PickRequest value)
        {
            Requests.Add(value);
        }

        // PUT: api/Picklists/5?lineId=10
        public void Put(string id, int lineId, [FromBody]PickRequest value)
        {
            var req = Requests.First(a => a.Id == id && a.LineId == lineId);
            req.IsSuccess = value.IsSuccess;
            req.ErrorMsg = value.ErrorMsg;
        }

        [Authorize]
        // DELETE: api/Picklists/5?lineId=10
        public HttpResponseMessage Delete(string id, int lineId)
        {
            if (!Requests.Any(a => a.Id == id && a.LineId == lineId))
                return Request.CreateResponse(HttpStatusCode.OK);

            var req = Requests.First(a => a.Id == id && a.LineId == lineId);
            return req.IsSuccess
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateResponse(HttpStatusCode.InternalServerError, req.ErrorMsg);

        }
    }

    public class PickRequest
    {
        public string Id { get; set; }
        public int LineId { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMsg { get; set; }
    }
}
