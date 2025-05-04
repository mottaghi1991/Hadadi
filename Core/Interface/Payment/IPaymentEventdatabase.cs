using Domain.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Payment
{
    public interface IPaymentEventdatabase
    {
        public PaymentEventDatabase Insert(PaymentEventDatabase paymentEventDatabase);
        public PaymentFinalEvent InsertFinal(PaymentFinalEvent paymentFinalEvent);
        public PaymentEventDatabase getPaymentEventByAuthority(string authority);
        public IEnumerable<PaymentFinalEvent> GetAllFinalEvents();
    }
}
