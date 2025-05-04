using Core.Interface.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminHomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IDistributedCache _cache;
        private readonly IPaymentEventdatabase _eventdatabase;

        public AdminHomeController(IDistributedCache cache, IPaymentEventdatabase eventdatabase)
        {
            _cache = cache;
            _eventdatabase = eventdatabase;
        }
        [Route("Admin")]
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult PaymentList()
        {
            var obj = _eventdatabase.GetAllFinalEvents();
            return View(obj);
        }

    
    }
}
