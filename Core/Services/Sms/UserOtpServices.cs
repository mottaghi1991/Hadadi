using Core.Interface.Sms;
using Data.MasterInterface;
using Domain.SMS;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Sms
{
    public class UserOtpServices : IUserOtp
    {
        private readonly IMaster<UserOtp> _master;
        private readonly IMemoryCache _cache;

        public UserOtpServices(IMaster<UserOtp> master, IMemoryCache cache)
        {
            _master = master;
            _cache = cache;
        }

        public bool AcceptCode(string PhoneNumber, string Code, DateTime EnterTime)
        {
            var obj = _master.GetAllEf().Where(o => o.PhoneNumber == PhoneNumber && o.Code == Code && !o.IsUsed && o.ExpireAt > EnterTime)
         .OrderByDescending(o => o.CreateAt)
         .FirstOrDefault();
            if (obj != null)
                return true;
            return false;
        }

        public bool CanTry(string phoneNumber)
        {
            var key = $"User_Try_{phoneNumber}";
            int tryCount = _cache.GetOrCreate(key, e => {
                e.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                return 0;
            });
            return tryCount < 5;
        }

        public void IncreaseTry(string phoneNumber)
        {
            var key = $"User_Try_{phoneNumber}";
            int tryCount = _cache.GetOrCreate(key, _ => 0) + 1;
            _cache.Set(key, tryCount, TimeSpan.FromMinutes(10));
        }

        public bool insert(UserOtp userOtp)
        {
            var obj = _master.Insert(userOtp);
            if (obj == null)
                return false;

            return true;
        }

        public void Reset(string phoneNumber)
        {
            _cache.Remove($"User_Try_{phoneNumber}");
        }

        public bool UseCode(string PhoneNumber, string Code)
        {
            var obj = _master.GetAllEf(a => a.PhoneNumber == PhoneNumber && a.Code == Code).FirstOrDefault();
            if (obj == null)
                return false;
            obj.IsUsed = true;
            var result = _master.Update(obj);
            if (result == null)
                return false;
            return true;
        }
    }
}
