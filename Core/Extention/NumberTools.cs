using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extention
{
    public static class Numbertools
    {
        public static string ToEnglishDigits(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            string[] persianDigits = new[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int i = 0; i < persianDigits.Length; i++)
                input = input.Replace(persianDigits[i], i.ToString());
            return input;
        }
    }
}
