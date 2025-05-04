using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    public static class CodeGenerator
    {
        public static string Generate()
        {
            var digits = "0123456789".ToCharArray();
            var random = new Random();
            var result = new char[6];

            // به‌هم ریختن ترتیب اعداد
            for (int i = 0; i < digits.Length; i++)
            {
                int j = random.Next(i, digits.Length);
                (digits[i], digits[j]) = (digits[j], digits[i]);
            }

            // گرفتن ۶ رقم اول از اعداد مخلوط شده
            Array.Copy(digits, result, 6);

            return new string(result);

        }
    }
}
