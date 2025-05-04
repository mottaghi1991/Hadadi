using Core.Interface.Exam;
using Data.MasterInterface;
using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exam
{
    public class ExamResultFinalServices : IExamResultFinals
    {
        private readonly IMaster<ExamResultFinal> _master;

        public ExamResultFinalServices(IMaster<ExamResultFinal> master)
        {
            _master = master;
        }

        public ExamResultFinal Insert(ExamResultFinal examResultFinal)
        {
            return _master.Insert(examResultFinal);
        }

        public ExamResultFinal resultFinal(string ResultText)
        {
            var obj= _master.GetAllEf(a => a.Title == ResultText).FirstOrDefault();
            if (obj != null) {
                return obj;
            }
             return new ExamResultFinal()
            {
                Descript = "لطفا با دفتر موسسه تماس حاصل فرمائید",
                FinalResult = "لطفا با دفتر موسسه تماس حاصل فرمائید.  <a href=\"tel:09386001031\">09386001031 - </a>\r\n        <a href=\"02144051174\">02144051174 - </a>\r\n        <a href=\"02144072340\">02144072340</a>"
            };
        }

        public IEnumerable<ExamResultFinal> resultFinalByExamId(int ExamId)
        {
            return _master.GetAllEf(a=>a.ExamId==ExamId);   
        }

        public ExamResultFinal resultFinalById(int ResultId)
        {
          return _master.GetAllEf(a=>a.Id==ResultId).FirstOrDefault();
        }

        public ExamResultFinal Update(ExamResultFinal examResultFinal)
        {
            return _master.Update(examResultFinal);
        }

      
    }
}
