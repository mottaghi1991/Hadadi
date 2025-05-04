using Core.Dto.ViewModel.Exam;
using Core.Enums;
using Core.Extention;
using Core.Interface.Exam;
using Core.Interface.Users;
using Domain.Exam;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using WebStore.Base;

namespace Personal.Areas.UserPanel.Controllers
{
    [Area(AreaNames.UserPanel)]
    [Authorize]
    public class ExamsController : BaseController
    {
        private readonly IJobQuestion _jobQuestion;
        private readonly IJobUserNaswer _jobUserNaswer;
        private readonly ISubOption _subOption;
        private readonly IQuestion _Question;
        private readonly IUserAnswer _userAnswer;
        private readonly IExamResult _examResult;
        private readonly IExamResultFinals _examResultFinal;
        private readonly INinQuestion _ninQuestion;
        private readonly INinExam _ninExam;
        private readonly IUser _user;




        public ExamsController(IJobQuestion jobQuestion, IJobUserNaswer jobUserNaswer, IUserAnswer userAnswer, IQuestion question, ISubOption subOption, IExamResult examResult, IExamResultFinals examResultFinal, INinQuestion ninQuestion, INinExam ninExam, IUser user)
        {
            _jobQuestion = jobQuestion;
            _jobUserNaswer = jobUserNaswer;
            _userAnswer = userAnswer;
            _Question = question;
            _subOption = subOption;
            _examResult = examResult;
            _examResultFinal = examResultFinal;
            _ninQuestion = ninQuestion;
            _ninExam = ninExam;
            _user = user;
        }

        public IActionResult Index()
        {
         
            var LoginUser = _user.GetUserByUserId(User.GetUserId());
            if (LoginUser.Family == null)
            {
              return  RedirectToAction("FillFamily", "User", new {area=AreaNames.UserPanel});
            }

            var list = _examResult.GetListOfUserExamByUserId(User.GetUserId());
            return View(list);
        }
        #region HalandExam
        public IActionResult GetExam(int? QuestionId)
        {
            var result = _userAnswer.GetmaxQuestionOfUserNaswer(User.GetUserId());
            if (result != 0)
            {
                int next = _Question.GetNextQuestionNum(result);
                var obj = _subOption.GetAllQuestion(next);
                return View(obj);
            }
            //noe azmon moshakhas gardad
            if (QuestionId == null || result==0)
            {
                return View(_subOption.GetAllQuestion(1));
            }
            //karbar ghablan soalat ra ta nime pasokh dade ast
            return View();
            

        }
        [HttpPost]
        public IActionResult SubmitExam(Dictionary<int, Dictionary<int, List<int>>> SelectedOptions)
        {
            if (SelectedOptions != null)
            {
                List<UserAnswer> answers = new List<UserAnswer>();
                foreach (var question in SelectedOptions)
                {
                    int questionId = question.Key;

                    foreach (var option in question.Value)
                    {
                        int optionId = option.Key;
                        List<int> selectedSubOptions = option.Value;

                        foreach (var subOptionId in selectedSubOptions)
                        {
                            answers.Add(new UserAnswer
                            {
                                QuestionId = questionId,
                                OptionId = optionId,
                                SubOptionId = subOptionId,
                                ItUserId = User.GetUserId(),
                                Score=null
                            });


                        }
                    }
                }
                _subOption.BulkInsert(answers);
            }

            return RedirectToAction("GetExam", new { QuestionId = SelectedOptions.Keys.FirstOrDefault() });
        }
        [HttpPost]
        public IActionResult SubmitExamFour([FromForm] Dictionary<int, int> Answers, [FromForm] Dictionary<int, int> QuestionIds, [FromForm] Dictionary<int, int> OptionIds)
        {
            List<UserAnswer> answers = new List<UserAnswer>();
            foreach (var answer in Answers)
            {
                var subOptionId = answer.Key;
                var score = answer.Value;
                var questionId = QuestionIds[subOptionId];
                var optionId = OptionIds[subOptionId];

                answers.Add(new UserAnswer
                {
                    SubOptionId = subOptionId,
                    Score = score,
                    QuestionId = questionId,
                    OptionId = optionId,
                    ItUserId = User.GetUserId(),
                    InsertDate = DateTime.Now
                });

               
            }


            _subOption.BulkInsert(answers);
            if (!_examResult.UserExistInExam(User.GetUserId(), (int)ExamId.Haland))
            {
                var res = _examResult.InsertUserExamDone(UserId: User.GetUserId(), ExamId: (int)ExamId.Haland);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ExamResult()
        {
            var status = _examResult.GetUserExamByUserAndExam(User.GetUserId(), (int)ExamId.Haland);
            if (!status.IsPay)
            {
                return RedirectToAction("StartPayment", "Payment", new { ExamId = (int)ExamId.Haland });
            }
            string Res = _examResult.HAlandResult(User.GetUserId());
            var Result= _examResultFinal.resultFinal(Res);
            if(Result==null)
            {
                return View(new ExamResultFinal()
                {
                    Descript = "لطفا با دفتر موسسه تماس حاصل فرمائید",
                    FinalResult = "لطفا با دفتر موسسه تماس حاصل فرمائید.  <a href=\"tel:09386001031\">09386001031</a>\r\n        <a href=\"02144051174\">02144051174</a>\r\n        <a href=\"02144072340\">02144072340</a>"
                });
            }
            return View(Result);
        }
        #endregion
        #region mbti
        public IActionResult JobExams()
        {
            var LastQuestionAnswer = _jobUserNaswer.GetLastQuestionNumber(User.GetUserId());
            if (LastQuestionAnswer == 0) {
                return View(_jobQuestion.ShowJobExamToUser(1));
                
            }
            var Current=_jobQuestion.GetQuestionById(LastQuestionAnswer).SeriShow;
            if(Current==4)
            {
                if (!_examResult.UserExistInExam(User.GetUserId(), (int)ExamId.MBTI))
                {
                    _examResult.InsertUserExamDone(User.GetUserId(), (int)ExamId.MBTI);
                }
                TempData[Success] = "آزمون با موفقیت به پایان رسید";
                return RedirectToAction("Index");
            }
                    return View(_jobQuestion.ShowJobExamToUser(Current + 1));
        }
        [HttpPost]
        public IActionResult SubmitJobTest(Dictionary<int, int> Answers)
        {
            List<JobUserAnswer> List = new List<JobUserAnswer>();
            foreach (var answer in Answers)
            {
                List.Add(new JobUserAnswer
                {
                    JobQuestionId = answer.Key,
                    OptionId = answer.Value,
                    UserId = User.GetUserId()
                });

            }

            _jobUserNaswer.BulkInsert(List);
           
            return RedirectToAction("JobExams");
        }


        public IActionResult ShowMbtiResult()
        {
            var status = _examResult.GetUserExamByUserAndExam(User.GetUserId(), (int)ExamId.MBTI);
            if (!status.IsPay)
            {
                return RedirectToAction("StartPayment", "Payment", new { ExamId = (int)ExamId.MBTI });
            }
            var a = _examResult.MBTIResult(User.GetUserId());
            var Result = _examResultFinal.resultFinal(a);
            if (Result == null)
            {
                return View(new ExamResultFinal()
                {
                    Descript = "لطفا با دفتر موسسه تماس حاصل فرمائید",
                    FinalResult = "لطفا با دفتر موسسه تماس حاصل فرمائید.  <a href=\"tel:09386001031\">09386001031</a>\r\n        <a href=\"02144051174\">02144051174</a>\r\n        <a href=\"02144072340\">02144072340</a>"
                });
            }
            return View(Result);
        }
#endregion
        #region Anageram

        public IActionResult NinExam(int SeriId)
        {
            IEnumerable<NinQuestion> Question =_ninQuestion.GetNextQuestions(SeriId, User.GetUserId());
            if (Question == null || !Question.Any())
            {
                if (!_examResult.UserExistInExam(User.GetUserId(), (int)ExamId.Anageram))
                {
                    _examResult.InsertUserExamDone(User.GetUserId(), (int)ExamId.Anageram);
                }
                TempData[Success] = "آزمون با موفقیت پایان پذیرفت";
                return RedirectToAction("Index");
            }
            var SerioObj = _ninExam.GetSeriById(Question.FirstOrDefault().seriId);
            if (SerioObj == null)
            {
                return NotFound();
            }
                   

               

            ViewBag.NinOptions=_ninQuestion.GetAllNinOption();
            return View(new NinQuestionViewModel()
            {
                SeriId = SeriId,
                SeriTitle = SerioObj.Title,
                SeriNumber = SerioObj.Number,
                ninQuestions = Question
            });
        }
        [HttpPost]
        public IActionResult NinExamSubmit(Dictionary<int,int> Answer)
        {
            List<NinUserAnswer> Answers = new List<NinUserAnswer>();
            foreach (var pair in Answer)
            {
                int questionId = pair.Key;
                int selectedOptionIds = pair.Value;
                Answers.Add(new NinUserAnswer()
                {
                    ItUserId = User.GetUserId(),
                    ninOptionId = selectedOptionIds,
                    ninQuestionId = questionId,

                });
               
            }
            var Result= _ninExam.BulkInsertUserAnswer(Answers);
            if (!Result)
            {
                TempData[Error]=ErrorMessage;
                return RedirectToAction("Index");
            }
            var Question = _ninQuestion.GetNinQuestionById(Answer.FirstOrDefault().Key);
            return RedirectToAction("NinExam", new
            {
                SeriId = Question.seriId,
            });
          }
        public IActionResult Result()
        {
            var status = _examResult.GetUserExamByUserAndExam(User.GetUserId(), (int)ExamId.Anageram);
            if(!status.IsPay)
            {
                return RedirectToAction("StartPayment", "Payment", new { ExamId = (int)ExamId.Anageram });
            }
      
            string Res = _examResult.AnageramResult(User.GetUserId());
            var Result = _examResultFinal.resultFinal(Res);
            if (Result == null)
            {
                return View(new ExamResultFinal()
                {
                    Descript = "لطفا با دفتر موسسه تماس حاصل فرمائید",
                    FinalResult = "لطفا با دفتر موسسه تماس حاصل فرمائید.  <a href=\"tel:09386001031\">09386001031</a>\r\n        <a href=\"02144051174\">02144051174</a>\r\n        <a href=\"02144072340\">02144072340</a>"
                });
            }
            return View(Result);
        }
        #endregion
    }
}
