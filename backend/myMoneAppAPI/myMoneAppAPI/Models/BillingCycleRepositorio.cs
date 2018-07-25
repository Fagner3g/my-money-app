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
                id = 1,
                name = "Janeiro",
                year = 2018,
                month = 9,
                credits = new List<Credito>()
                    {
                        new Credito {
                            name = "Diversas",
                            value = 1500
                        },
                        new Credito {
                            name = "Pagamento Salário",
                            value = 1500
                        }
                },
                debts = new List<Debito>() {
                    new Debito
                    {
                        name = "Pagamento Academia",
                        value = 70,
                        status = "Pago"
                    },
                    new Debito
                    {
                        name = "Pagamento Gasolina",
                        value = 570,
                        status = "Pendente"
                    },

                }
            });
            Add(new BillingCycle
            {
                id = 2,
                name = "Fevereiro",
                year = 2018,
                month = 5,
                credits = new List<Credito>()
                    {
                        new Credito {
                            name = "Diversas",
                            value = 6
                        },
                        new Credito {
                            name = "Pagamento Salário",
                            value = 900
                        }
                },
                debts = new List<Debito>() {
                    new Debito
                    {
                        name = "Pagamento Academia",
                        value = 70,
                        status = "Pago"
                    },
                    new Debito
                    {
                        name = "Pagamento Diversos",
                        value = 570,
                        status = "Pendente"
                    },

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
            return billingRepositorio.Find(b => b.id == id);
        }

        public IEnumerable<BillingCycle> GetAll()
        {
            return billingRepositorio;
        }

        public void Remove(int id)
        {
            billingRepositorio.RemoveAll(b => b.id == id);
        }

        public bool Update(BillingCycle billing)
        {
            if (billing == null)
                throw new ArgumentException("Billing not Null");

            int index = billingRepositorio.FindIndex(b => b.id == billing.id);
            if (index == -1)
                return false;

            billingRepositorio.RemoveAt(index);
            billingRepositorio.Add(billing);
            return true;
        }
    }
}