using Core.Interface.Payment;
using Domain.Payment;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Payment
{
    public class ZarinpalPaymentGateway : IPaymentGateway
    {
        private readonly string _merchantId = "f95edfe9-ad78-4e9b-9229-d63b6c90f8ac";
        private readonly HttpClient _httpClient;

        public ZarinpalPaymentGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }

        public PaymentFirstResponse RequestPayment(int amount, string callbackUrl, string description, string email, string mobile)
        {
            var requestData =new PaymentRequest()
            {
                merchant_id = _merchantId,
                amount = amount,
                callback_url =""+  callbackUrl,
                description = description,
                Metadata=new Metadata
                {
                    Email = email,
                    Mobile = mobile 
                }
             
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync("https://api.zarinpal.com/pg/v4/payment/request.json", content).GetAwaiter().GetResult();
            var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            dynamic result = JsonConvert.DeserializeObject<dynamic>(responseContent);

            if (result.data.code != null )
            {
                    return new PaymentFirstResponse
                {
                 data=new PaymentFirstResponse.Data
                 {
                     authority=result.data.authority,
                     code=result.data.code,
                     fee=result.data.fee,   
                     fee_type=result.data.fee_type, 
                     message=result.data.message,
                 },
                 
                };
          
            }
            else
            {
                return new PaymentFirstResponse
                {
                    Error = new PaymentFirstResponse.Errors
                    {
                        message=result.errors.message,
                        code  = result.errors.code,

                    },

                };
            }
        }

        public PaymentFinalResponse VerifyPayment(string authority,int Amount)
        {
      
            var requestData = new 
            {
                merchant_id = _merchantId,
                authority = authority,
                amount = Amount // 🔥 باید Amount صحیح اینجا باشه (مثلاً از دیتابیس بخونی)
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync("https://api.zarinpal.com/pg/v4/payment/verify.json", content).GetAwaiter().GetResult();
            var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            dynamic result = JsonConvert.DeserializeObject<dynamic>(responseContent);
            PaymentFinalResponse final = new PaymentFinalResponse();
            if (result.data.code == 100 || result.data.code == 101)
            {
                final.data =       new PaymentFinalResponse.Data()
                {
                    code = result.data.code,
                    Message = result.data.message,
                    card_hash = result.data.card_hash,
                    card_pan = result.data.card_pan,
                    ref_id = result.data.ref_id,
                    fee = result.data.fee,
                    fee_type = result.data.fee_type,
                 
                  
                };
            }
            else
            {
                final.Error = new PaymentFinalResponse.Errors()
                {
                    code = result.errors.code,
                    message = result.errors.message,
                    
                };
            }
            return final;
        }

      

    }

}
