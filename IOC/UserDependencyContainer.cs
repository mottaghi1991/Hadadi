﻿using Core.Dto.ViewModel.Exam;
using Core.Dto.ViewModel.User;
using Core.Interface.Admin;
using Core.Interface.Exam;
using Core.Interface.Payment;
using Core.Interface.Sms;
using Core.Interface.Users;
using Core.Services.Exam;
using Core.Services.Payment;
using Core.Services.Sms;
using Core.Services.Users;
using Data.MasterInterface;
using Data.MasterServices;
using Domain.Exam;
using Domain.Payment;
using Domain.SMS;
using Domain.User;
using Domain.User.Permission;
using Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public class UserDependencyContainer
    {
        public static void RegisterServices(IServiceCollection Services)
        {
            #region payment
            //Services.AddScoped<IPaymentGateway, ZarinpalPaymentGateway>();
            Services.AddHttpClient<IPaymentGateway, ZarinpalPaymentGateway>();
            

            #endregion

            #region Admin
            Services.AddScoped<IUser, UserServices>();



            #endregion

            #region User
            Services.AddScoped<IUser, UserServices>();
            Services.AddScoped<IPermisionList, PermissionListServices>();
            Services.AddScoped<IRole, RoleServices>();
            Services.AddScoped<IRolePermission, RolePermissionServices>();
            Services.AddScoped<IViewRender, RenderViewToStringServices>();


            Services.AddScoped<IMaster<PermissionList>, MasterServices<PermissionList>>();
            Services.AddScoped<IMaster<MyUser>, MasterServices<MyUser>>();
            Services.AddScoped<IMaster<Role>, MasterServices<Role>>();
            Services.AddScoped<IMaster<RolePermission>, MasterServices<RolePermission>>();
            Services.AddScoped<IMaster<UserRole>, MasterServices<UserRole>>();
            #endregion
            #region Exam
            Services.AddScoped<ISubOption, SubOptionServices>();
            Services.AddScoped<IQuestion, QuestionServices>();
            Services.AddScoped<IUserAnswer, UserAnswerServices>();
            Services.AddScoped<IOption, OptionServices>();
            Services.AddScoped<IJobQuestion, JobQuestionServices>();
            Services.AddScoped<IJobUserNaswer, JobUserAnswerServices>();
            Services.AddScoped<IJobOption, JobOptionServices>();
            Services.AddScoped<INinQuestion,ninQuestionServices>();
            Services.AddScoped<INinExam,NinExamServices>();
            Services.AddScoped<IExamResult,ExamResultServices>();
            Services.AddScoped<IExamResultFinals,ExamResultFinalServices>();
            Services.AddScoped<IPaymentEventdatabase,PaymentEventDatabaseServices>();






            Services.AddScoped<IMaster<UserAnswer>, MasterServices<UserAnswer>>();
            Services.AddScoped<IMaster<Question>, MasterServices<Question>>();
            Services.AddScoped<IMaster<Option>, MasterServices<Option>>();
            Services.AddScoped<IMaster<SubOption>, MasterServices<SubOption>>();
            Services.AddScoped<IMaster<JobQuestion>, MasterServices<JobQuestion>>();
            Services.AddScoped<IMaster<JobUserAnswer>, MasterServices<JobUserAnswer>>();
            Services.AddScoped<IMaster<JobOption>, MasterServices<JobOption>>();
            Services.AddScoped<IMaster<JobGroupIndex>, MasterServices<JobGroupIndex>>();
            Services.AddScoped<IMaster<NinQuestion>, MasterServices<NinQuestion>>();
            Services.AddScoped<IMaster<Seri>, MasterServices<Seri>>();
            Services.AddScoped<IMaster<UserExam>, MasterServices<UserExam>>();
            Services.AddScoped<IMaster<ExamResultFinal>, MasterServices<ExamResultFinal>>();
            Services.AddScoped<IMaster<NinOption>, MasterServices<NinOption>>();
            Services.AddScoped<IMaster<NinUserAnswer>, MasterServices<NinUserAnswer>>();
            Services.AddScoped<IMaster<ExamList>, MasterServices<ExamList>>();
            Services.AddScoped<IMaster<PaymentEventDatabase>, MasterServices<PaymentEventDatabase>>();
            Services.AddScoped<IMaster<PaymentFinalEvent>, MasterServices<PaymentFinalEvent>>();




            Services.AddScoped<IMaster<ShowExamToUserViewModel>, MasterServices<ShowExamToUserViewModel>>();
            Services.AddScoped<IMaster<ExamResultViewModel>, MasterServices<ExamResultViewModel>>();
            Services.AddScoped<IMaster<JobTestViewModel>, MasterServices<JobTestViewModel>>();
            Services.AddScoped<IMaster<ShowUserBrifViewModel>, MasterServices<ShowUserBrifViewModel>>();
            Services.AddScoped<IMaster<ExamDetailItem>, MasterServices<ExamDetailItem>>();
            #endregion
            #region Sms
            Services.AddScoped<ISms, SmsIRServices>();
            Services.AddScoped<IUserOtp, UserOtpServices>();


            Services.AddScoped<IMaster<UserOtp>, MasterServices<UserOtp>>();

            #endregion
        }
    }
}
