using System;
using System.Collections.Generic;

namespace myMoneAppAPI.Models
{
    public class BillingCycleRepositorio : IBillingCycleRepositorio
    {
        private List<BillingCycle> billingRepositorio = new List<BillingCycle>();

        public BillingCycleRepositorio()
        {
            Add(new BillingCycle
            {
                ID = 1,
                Name = "Teste Da API",
                Year = 2018,
                Month = 9,
                Credito = new Credito
                {
                    Name = "Pagamento de Salário",
                    Value = 20000
                },
                Debito = new Debito
                {
                    Name = "Pagamento de Academia",
                    Value = 100
                }
            });
            Add(new BillingCycle
            {
                ID = 2,
                Name = "Teste Da API número 2",
                Year = 2018,
                Month = 10,
                Credito = new Credito
                {
                    Name = "Pagamento de Salário BH",
                    Value = 1500
                },
                Debito = new Debito
                {
                    Name = "Pagamento de Academia São Paulo",
                    Value = 150
                }
            });
            Add(new BillingCycle
            {
                ID = 3,
                Name = "Produção de Teste",
                Year = 2018,
                Month = 10,
                Credito = new Credito
                {
                    Name = "Pagamento de Salário BH",
                    Value = 1500
                },
                Debito = new Debito
                {
                    Name = "Pagamento de Academia São Paulo",
                    Value = 150
                }
            });
        }

        public bool Add(BillingCycle billing)
        {
            int i = billingRepositorio.Count + 1;

            billingRepositorio.Add(billing);
            return true;
        }

        public BillingCycle Get(int id)
        {
            return billingRepositorio.Find(b => b.ID == id);
        }

        public IEnumerable<BillingCycle> GetAll()
        {
            return billingRepositorio;
        }

        public void Remove(int id)
        {
            billingRepositorio.RemoveAll(b => b.ID == id);
        }

        public bool Update(BillingCycle billing)
        {
            if (billing == null)
                throw new ArgumentException("Billing not Null");

            int index = billingRepositorio.FindIndex(b => b.ID == billing.ID);
            if (index == -1)
                return false;

            billingRepositorio.RemoveAt(index);
            billingRepositorio.Add(billing);
            return true;
        }
    }
}