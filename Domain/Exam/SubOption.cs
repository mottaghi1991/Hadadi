﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class SubOption:BaseModel
    {
        public string Title { get; set; }
        public int OptionId { get; set; }
        public int Order { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey("OptionId")]
        public Option Option { get; set; }
        public Question Question { get; set; }

    }
}
