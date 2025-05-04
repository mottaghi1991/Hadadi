using Core.Interface.Payment;
using Data.MasterInterface;
using Domain.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Payment
{
    public class PaymentEventDatabaseServices : IPaymentEventdatabase
    {
        private readonly IMaster<PaymentEventDatabase> _master;
        private readonly IMaster<PaymentFinalEvent> _Finamaster;

        public PaymentEventDatabaseServices(IMaster<PaymentEventDatabase> master, IMaster<PaymentFinalEvent> finamaster)
        {
            _master = master;
            _Finamaster = finamaster;
        }

        public IEnumerable<PaymentFinalEvent> GetAllFinalEvents()
        {
           return _Finamaster.GetAllAsQueryable().Include(a=>a.myUser).Include(a=>a.examList).Where(a => a.code == 100 | a.code == 101).OrderByDescending(a=>a.InsertDate).ToList();
        }

        public PaymentEventDatabase getPaymentEventByAuthority(string authority)
        {
         return _master.GetAllEf(a=>a.authority == authority).FirstOrDefault();
        }

        public PaymentEventDatabase Insert(PaymentEventDatabase paymentEventDatabase)
        {
          return _master.Insert(paymentEventDatabase);
        }

        public PaymentFinalEvent InsertFinal(PaymentFinalEvent paymentFinalEvent)
        {
 return _Finamaster.Insert(paymentFinalEvent);
        }
    }
}
