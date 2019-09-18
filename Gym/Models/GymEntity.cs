namespace Gym.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GymEntity : DbContext
    {
        public GymEntity()
            : base("name=GymEntity")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseSeries> CourseSeries { get; set; }
        public virtual DbSet<CourseSeriesDetail> CourseSeriesDetail { get; set; }
        public virtual DbSet<CourseType> CourseType { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberAccess> MemberAccess { get; set; }
        public virtual DbSet<MemberCourse> MemberCourse { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>()
                .Property(e => e.ClassroomNo)
                .IsUnicode(false);

            modelBuilder.Entity<Classroom>()
                .Property(e => e.Store_No)
                .IsUnicode(false);

            modelBuilder.Entity<Classroom>()
                .HasMany(e => e.Course)
                .WithRequired(e => e.Classroom)
                .HasForeignKey(e => e.Classroom_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseType_No)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Classroom_No)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Teacher_No)
                .IsUnicode(false);

            modelBuilder.Entity<CourseSeries>()
                .Property(e => e.CourseSeriesNo)
                .IsUnicode(false);

            modelBuilder.Entity<CourseSeries>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CourseSeries>()
                .HasMany(e => e.CourseSeriesDetail)
                .WithRequired(e => e.CourseSeries)
                .HasForeignKey(e => e.CourseSeries_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseSeries>()
                .HasMany(e => e.MemberCourse)
                .WithRequired(e => e.CourseSeries)
                .HasForeignKey(e => e.CourseSeries_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseSeriesDetail>()
                .Property(e => e.CourseSeries_No)
                .IsUnicode(false);

            modelBuilder.Entity<CourseSeriesDetail>()
                .Property(e => e.CourseType_No)
                .IsUnicode(false);

            modelBuilder.Entity<CourseType>()
                .Property(e => e.CourseNo)
                .IsUnicode(false);

            modelBuilder.Entity<CourseType>()
                .HasMany(e => e.Course)
                .WithRequired(e => e.CourseType)
                .HasForeignKey(e => e.CourseType_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseType>()
                .HasMany(e => e.CourseSeriesDetail)
                .WithRequired(e => e.CourseType)
                .HasForeignKey(e => e.CourseType_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberAccess)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Member_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberCourse)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.Member_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Store)
                .WithMany(e => e.Member)
                .Map(m => m.ToTable("Member to Store").MapLeftKey("Member_No").MapRightKey("Store_No"));

            modelBuilder.Entity<MemberAccess>()
                .Property(e => e.Store_No)
                .IsUnicode(false);

            modelBuilder.Entity<MemberCourse>()
                .Property(e => e.MemberCourseNo)
                .IsUnicode(false);

            modelBuilder.Entity<MemberCourse>()
                .Property(e => e.CourseSeries_No)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Member)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.Role_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.StoreNo)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Classroom)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.Store_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.MemberAccess)
                .WithRequired(e => e.Store)
                .HasForeignKey(e => e.Store_No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.TeacherNo)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Course)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.Teacher_No)
                .WillCascadeOnDelete(false);
        }
    }
}
