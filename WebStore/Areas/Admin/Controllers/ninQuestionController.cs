﻿using Core.Dto.ViewModel.Exam;
using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    [Authorize]
    public class ninQuestionController : BaseController
    {
        private readonly INinQuestion _ninQuestion;
        private readonly INinExam _inExam;

        public ninQuestionController(INinQuestion ninQuestion, INinExam inExam)
        {
            _ninQuestion = ninQuestion;
            _inExam = inExam;
        }
        public IActionResult Seris()
        {
            return View(_inExam.GetAllSeri());
        }
        public IActionResult ManageNinExam()
        {
            return View();
        }
        public IActionResult Index(int seriId)
        {
            
            if(seriId==0)
            {
                return RedirectToAction("Seris");
            }
            var SeriObj = _inExam.GetSeriById(seriId);
            if (SeriObj == null)
            {
                return NotFound();
            }
            return View(
                new NinQuestionViewModel()
                {
                    SeriId = seriId,
                SeriTitle=SeriObj.Title,
                SeriNumber=SeriObj.Number,
                    ninQuestions=_ninQuestion.GetNinQuestionBySeriId(seriId)
                }
                
                );
        }
        // GET: RoleController/Create
        public ActionResult Create(int SeriId)
        {
            return View(new NinQuestion()
            {
                seriId = SeriId,
            });
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NinQuestion NinQuestion)
        {
           

                if (!ModelState.IsValid)
                {
                    return View(NinQuestion);
                }

                var result = _ninQuestion.Insert(NinQuestion);
                if (result != null)
                {
                    TempData[Success] = SuccessMessage;
                    return RedirectToAction("Index", new { seriId =result.seriId});
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    return View(NinQuestion);
                }
            }
          
        // GET: RoleController/Edit/5
        public ActionResult Edit(int Id)
        {

            var result = _ninQuestion.GetNinQuestionById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NinQuestion NinQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View(NinQuestion);
            }




            var result = _ninQuestion.Update(NinQuestion);
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index", new { seriId = result.seriId });
            }
            else
            {
                TempData[Error] = ErrorMessage;
                return View(NinQuestion);
            }

        }

    }
}
