using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myMoneAppAPI.Models
{
    public interface IBillingCycleRepositorio
    {
        IEnumerable<BillingCycle> GetAll();
        BillingCycle Get(int id);
        bool Add(BillingCycle billing);
        void Remove(int id);
        bool Update(BillingCycle billing);
    }
}