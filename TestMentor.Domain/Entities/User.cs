using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMentor.Domain.EnumeratesConstants;

namespace TestMentor.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public int UserStatusId { get; set; }
        public virtual UserStatus? UserStatus { get; set; }
        public Enumerates.Gender Gender { get; set; }
        public virtual ICollection<ConfirmEmail>? ConfirmEmails { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
        public virtual ICollection<Permission>? Permissions { get; set; }
        public virtual ICollection<AssigningTeachingAssistants>? AssigningTeachingAssistants { get; set; }
        public virtual ICollection<RegisterCourse>? RegisterCourses { get; set; }
        public virtual ICollection<UserLessonCheckpoint>? UserLessonCheckpoints { get; set; }
        public virtual ICollection<CommentLesson>? CommentLessons { get; set;}
    }
}
