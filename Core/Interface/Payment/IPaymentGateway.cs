
using Domain.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Payment
{
    public interface IPaymentGateway
    {
     public PaymentFirstResponse RequestPayment(int amount, string callbackUrl, string description, string email, string mobile);
       public PaymentFinalResponse VerifyPayment(string authority, int Amount);
    }
 
}
