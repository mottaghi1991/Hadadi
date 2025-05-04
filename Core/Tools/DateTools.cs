using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Static
{
    public static class DateTools
    {
        public static string ChangeToPersian(this DateTime date)
        {
            DateTime gregorianDate = date;

            // ایجاد شیء تقویم شمسی
            PersianCalendar persianCalendar = new PersianCalendar();

            // استخراج روز، ماه و سال شمسی
            int persianYear = persianCalendar.GetYear(gregorianDate);
            int persianMonth = persianCalendar.GetMonth(gregorianDate);
            int persianDay = persianCalendar.GetDayOfMonth(gregorianDate);
            int hhour = persianCalendar.GetHour(gregorianDate);
            int min = persianCalendar.GetMinute(gregorianDate);
            return ("(" + hhour + ":" + min + ")" + persianYear + "/"+ persianMonth+"/" + persianDay  ).ToString();
    
        }
        static string GetPersianMonthName(int month)
        {
            string[] persianMonthNames =
            {
                "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
                "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
            };
            return persianMonthNames[month - 1];
        }
    }
}
