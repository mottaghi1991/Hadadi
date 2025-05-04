using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User.Permission;
using Microsoft.EntityFrameworkCore;
using Domain.Users;
using Domain.User;
using Domain.Exam;
using Domain;
using Domain.Payment;
using Domain.SMS;

namespace Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }
        #region Permission
        public virtual DbSet<MyUser> MyUser { get; set; }
        public virtual DbSet<PermissionList> PermissionList { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        #endregion
        #region Exam
        public virtual DbSet<Question> Questions{ get; set; }
        public virtual DbSet<Option> Options{ get; set; }
        public virtual DbSet<SubOption> SubOptions{ get; set; }
        public virtual DbSet<UserAnswer> UserAnswers{ get; set; }

        public virtual DbSet<JobQuestion> JobQuestions{ get; set; }
        public virtual DbSet<JobOption> JobOptions { get; set; }
        public virtual DbSet<JobUserAnswer> JobUserAnswers{ get; set; }


        public virtual DbSet<NinQuestion> NinQuestions{ get; set; }
        public virtual DbSet<NinOption> NinOptions{ get; set; }
        public virtual DbSet<NinUserAnswer> NinUserAnswers{ get; set; }

        public virtual DbSet<UserExam> UserExams{ get; set; }
        public virtual DbSet<ExamResultFinal>ExamResultFinals{ get; set; }
        #endregion
        #region Payment
        public virtual DbSet<PaymentEventDatabase> PaymentEventDatabases{ get; set; }
        public virtual DbSet<PaymentFinalEvent> PaymentFinalEvents{ get; set; }
        #endregion

        #region SMS
        public virtual DbSet<UserOtp> UserOtps { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    var prop = entityType.FindProperty(nameof(BaseModel.IsDelete));
                    if (prop != null)
                    {
                        prop.SetDefaultValue(false);
                    }
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
