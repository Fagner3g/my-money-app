using myMoneAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace myMoneAppAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class BillingCycleController : ApiController
    {
        static readonly IBillingCycleRepositorio billingRepositorio = new BillingCycleRepositorio();

        public HttpResponseMessage GetAllBillingCycle()
        {
            List<BillingCycle> billingCycles = billingRepositorio.GetAll().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, billingCycles);
        }

        public HttpResponseMessage GetBillingCycle(int id)
        {
            List<BillingCycle> billingCycles = new List<BillingCycle>();
            billingCycles.Add(billingRepositorio.Get(id));

            if (billingCycles.Count == 0)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Billing Não encontrado");
            else
                return Request.CreateResponse(HttpStatusCode.OK, billingCycles);
        }

        public HttpResponseMessage PostBillingCycle(BillingCycle billing)
        {
            bool result = billingRepositorio.Add(billing);
            if (result)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, billing);
                string uri = Url.Link("DefaultApi", new { id = billing.ID });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Billing obteve erro para ser inserido.");
        }

        public HttpResponseMessage PutBillingCycle(int id, BillingCycle billing)
        {
            if (!billingRepositorio.Update(billing))
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, "Não foi possível atualizar seus dados");
            else
                return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage DeleteBillingCycle(int id)
        {
            billingRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
