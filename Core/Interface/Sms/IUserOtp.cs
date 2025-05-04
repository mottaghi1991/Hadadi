using Domain.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Sms
{
    public interface IUserOtp
    {
        public bool insert(UserOtp userOtp);
        public bool AcceptCode(string PhoneNumber, string Code, DateTime EnterTime);
        public bool UseCode(string PhoneNumber, string Code);
        public bool CanTry(string phoneNumber);
        public void IncreaseTry(string phoneNumber);
        public void Reset(string phoneNumber);

    }
}
