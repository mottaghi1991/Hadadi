using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class JobQuestion:BaseModel
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string  Title{ get; set; }
        public int SeriShow { get; set; }
        public virtual IEnumerable<JobOption> JobOptions { get; set; }  
        public virtual IEnumerable<JobUserAnswer> JobUserAnswers{ get; set; }  
    }
}
