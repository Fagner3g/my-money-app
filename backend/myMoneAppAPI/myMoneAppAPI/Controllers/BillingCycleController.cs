using myMoneAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace myMoneAppAPI.Controllers
{
    [Authorize]
    public class BillingCycleController : ApiController
    {
        static readonly IBillingCycleRepositorio billingRepositorio = new BillingCycleRepositorio();

        public HttpResponseMessage GetAllBillingCycle()
        {
            List<BillingCycle> billingCycles = billingRepositorio.GetAll().OrderBy(x => x.year).ToList();
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
            var r = billingRepositorio.GetAll();
            billing.id = r.Count() +1;

            if (string.IsNullOrEmpty(billing.name) || int.Equals(billing.month, 0) )
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Erro ao tentar criar ciclo.");
            bool result = billingRepositorio.Add(billing);
            if (result)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, billing);
                string uri = Url.Link("DefaultApi", new { billing.id });
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

        [HttpGet]
        [Route("api/Summary")]
        public Summary GetSummary()
        {
            decimal debito = 0, credito = 0;
            foreach (var item in billingRepositorio.GetAll())
            {
                foreach (var credits in item.credits)
                {
                    credito += credits.value;
                }
                foreach (var debits in item.debts)
                {
                    debito += debits.value;
                }
            }

            var summary = new Summary
            {
                debt = debito,
                credit = credito
            };
            return summary;
        }
    }
}
