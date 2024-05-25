using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.Entities;

namespace TestMentor.Infrastructure.DataContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<AssigningTeachingAssistants> AssigningTeachingAssistants { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<AttendanceStatus> AttendanceStatuses { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<ChapterStudy> ChapterStudies { get; set; }
        public virtual DbSet<CommentLesson> CommentLessons { get; set; }
        public virtual DbSet<ConfirmEmail> ConfirmEmails { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<LessonStatus> LessonStatuses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<RegisterCourse> RegisterCourses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLessonCheckpoint> UserLessonCheckpoints { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }
        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
