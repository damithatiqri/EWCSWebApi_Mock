using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWCSWebApi_Mock.Controllers
{
    public class GoodsReceivalsController : ApiController
    {
        private static readonly List<Request> Requests = new List<Request>();

        // GET: api/GoodsReceivals
        public IEnumerable<Request> Get()
        {
            return Requests;
        }

        // GET: api/GoodsReceivals/5?lineId=10
        public Request Get(int id, int lineId)
        {
            return Requests.First(a => a.Id == id && a.LineId == lineId);
        }

        // POST: api/GoodsReceivals
        public void Post([FromBody]Request value)
        {
            Requests.Add(value);
        }

        // PUT: api/GoodsReceivals/5?lineId=10
        public void Put(int id, int lineId, [FromBody]Request value)
        {
            var req = Requests.First(a => a.Id == id && a.LineId == lineId);
            req.IsSuccess = value.IsSuccess;
            req.ErrorMsg = value.ErrorMsg;
        }

        [Authorize]
        // DELETE: api/GoodsReceivals/5?lineId=10
        public HttpResponseMessage Delete(int id, int lineId)
        {
            if (!Requests.Any(a => a.Id == id && a.LineId == lineId))
                return Request.CreateResponse(HttpStatusCode.OK);

            var req = Requests.First(a => a.Id == id && a.LineId == lineId);
            return req.IsSuccess
                ? Request.CreateResponse(HttpStatusCode.OK)
                : Request.CreateResponse(HttpStatusCode.InternalServerError, req.ErrorMsg);

        }
    }

    public class Request
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMsg { get; set; }
    }
}
