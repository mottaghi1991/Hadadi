﻿using Core.Dto.ViewModel.Exam;
using Core.Interface.Admin;
using Core.Interface.Exam;
using Core.Interface.Users;
using Core.Services.Exam;
using Core.Services.Users;
using Data.MasterInterface;
using Data.MasterServices;
using Domain.Exam;
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
           




            Services.AddScoped<IMaster<UserAnswer>, MasterServices<UserAnswer>>();
            Services.AddScoped<IMaster<Question>, MasterServices<Question>>();
            Services.AddScoped<IMaster<Option>, MasterServices<Option>>();




            Services.AddScoped<IMaster<ShowExamToUserViewModel>, MasterServices<ShowExamToUserViewModel>>();
            Services.AddScoped<IMaster<ExamResultViewModel>, MasterServices<ExamResultViewModel>>();
            #endregion

        }
    }
}
