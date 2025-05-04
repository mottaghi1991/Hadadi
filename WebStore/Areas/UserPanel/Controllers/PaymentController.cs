using Core.Extention;
using Core.Interface.Exam;
using Core.Interface.Payment;
using Core.Services.Exam;
using Core.Services.Payment;
using Domain.Exam;
using Domain.Payment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlX.XDevAPI.Common;
using System;
using System.Threading.Tasks;
using WebStore.Base;
using ZarinPal.Class;
using ZarinpalSandbox;

namespace Personal.Areas.UserPanel.Controllers
{
    [Area(AreaNames.UserPanel)]
    public class PaymentController : BaseController
    {
        private readonly IPaymentGateway _paymentService;
        private readonly IPaymentEventdatabase _paymentEventdatabase;
        private readonly IExamResult _examResult;
        private readonly IConfiguration _configuration;

        public PaymentController(IPaymentGateway paymentService, IPaymentEventdatabase paymentEventdatabase, IExamResult examResult, IConfiguration configuration)
        {
            _paymentService = paymentService;
            _paymentEventdatabase = paymentEventdatabase;
            _examResult = examResult;
            _configuration = configuration;
        }
        //https://localhost:44347/UserPanel/Payment/StartPayment
        public IActionResult StartPayment(int ExamId,int price)
        {
         
            string Url= _configuration.GetValue<string>("ExamSettings:callBackUrl");
            // درخواست پرداخت
            var paymentRequest = _paymentService.RequestPayment(price, Url , "خرید محصول", "", "");

            if (paymentRequest.data!=null)
            {
                _paymentEventdatabase.Insert(new PaymentEventDatabase
                {
                    authority = paymentRequest.data.authority,
                    code = paymentRequest.data.code,
                    fee = paymentRequest.data.fee,
                    fee_type = paymentRequest.data.fee_type,
                    message = paymentRequest.data.message,
                    UserId = User.GetUserId(),
                    Price= price,
                    ExamId = ExamId
                });
                return RedirectToAction("SendTOBank", new { Url = "https://zarinpal.com/pg/StartPay/" + paymentRequest.data.authority});
             
            }
            else
            {
                _paymentEventdatabase.Insert(new PaymentEventDatabase
                {
                   
                    code = paymentRequest.Error.code,
                    message = paymentRequest.Error.message,
                    UserId = User.GetUserId(),
                    Price = price,
                    ExamId = ExamId
                });
                TempData[Error] = "صفحه پرداخت با مشکل مواجه گردیده است";
                // نمایش خطا
                return RedirectToAction( "Index", "Exams");
            }
        }
        public IActionResult SendTOBank(string Url)
        {
          
            return Redirect(Url);
        }
        [Route("/Response")]
        public IActionResult PaymentResponse(string Authority,string Status)
        {
            var payevent = _paymentEventdatabase.getPaymentEventByAuthority(Authority);
            if (Status =="OK")
            {
        
                var verifyResult = _paymentService.VerifyPayment(Authority, payevent.Price);
            
                if(verifyResult.data!=null)
                {
                    _paymentEventdatabase.InsertFinal(new PaymentFinalEvent()
                    {
                        card_hash = verifyResult.data.card_hash,
                        card_pan = verifyResult.data.card_pan,
                        code = verifyResult.data.code,
                        fee = verifyResult.data.fee,
                        fee_type = verifyResult.data.fee_type,
                        Message = verifyResult.data.Message,
                        ref_id = verifyResult.data.ref_id,
                        UserId = User.GetUserId(),
                        Price= payevent.Price,
                        ExamId=payevent.ExamId,
                        InsertDate=DateTime.Now
                    });
                    _examResult.UpdateUserToPay(User.GetUserId(), payevent.ExamId);
                }
                else if(verifyResult.Error!=null)
                {

                    _paymentEventdatabase.InsertFinal(new PaymentFinalEvent()
                    {
                   
                        code = verifyResult.Error.code,
                        Message = verifyResult.Error.message,
                        UserId = User.GetUserId(),
                        Price = payevent.Price,
                        ExamId = payevent.ExamId
                    });

                    TempData[Error] = " پرداخت با مشکل مواجه گردیده است";
                    // نمایش خطا
                    return RedirectToAction("Index", "Exams");
                }
            }
            if (Status == "NOK")
            {
                _paymentEventdatabase.InsertFinal(new PaymentFinalEvent()
                {

                    code = 1,
                    Message = "User Cancell Pay",
                    UserId = User.GetUserId(),
                    Price = payevent.Price,
                    ExamId = payevent.ExamId
                });
                TempData[Error] = " پرداخت با مشکل مواجه گردیده است";
                // نمایش خطا
                return RedirectToAction("Index", "Exams");
            }


            TempData[Success] = " از پرداخت شما متشکریم";
            // نمایش خطا
            return RedirectToAction("Index", "Exams");
        }
    }
    
}

