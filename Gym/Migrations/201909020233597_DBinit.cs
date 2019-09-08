namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBinit : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Course to Teacher", "Course_No", "dbo.Course");
            //DropForeignKey("dbo.Course to Teacher", "Teacher_No", "dbo.Teacher");
            //DropForeignKey("dbo.Course to Classroom", "Classroom_No", "dbo.Classroom");
            //DropForeignKey("dbo.Course to Classroom", "Course_No", "dbo.Course");
            //DropIndex("dbo.Course to Teacher", new[] { "Course_No" });
            //DropIndex("dbo.Course to Teacher", new[] { "Teacher_No" });
            //DropIndex("dbo.Course to Classroom", new[] { "Classroom_No" });
            //DropIndex("dbo.Course to Classroom", new[] { "Course_No" });
            //AddColumn("dbo.CourseItem", "Classroom_No", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddColumn("dbo.CourseItem", "Teacher_No", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddColumn("dbo.Store", "MemberInCnt", c => c.Int());
            //CreateIndex("dbo.CourseItem", "Classroom_No");
            //CreateIndex("dbo.CourseItem", "Teacher_No");
            //AddForeignKey("dbo.CourseItem", "Teacher_No", "dbo.Teacher", "TeacherNo");
            //AddForeignKey("dbo.CourseItem", "Classroom_No", "dbo.Classroom", "ClassroomNo");
            //DropTable("dbo.Course to Teacher");
            //DropTable("dbo.Course to Classroom");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Course to Classroom",
            //    c => new
            //        {
            //            Classroom_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Course_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //        })
            //    .PrimaryKey(t => new { t.Classroom_No, t.Course_No });
            
            //CreateTable(
            //    "dbo.Course to Teacher",
            //    c => new
            //        {
            //            Course_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Teacher_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //        })
            //    .PrimaryKey(t => new { t.Course_No, t.Teacher_No });
            
            //DropForeignKey("dbo.CourseItem", "Classroom_No", "dbo.Classroom");
            //DropForeignKey("dbo.CourseItem", "Teacher_No", "dbo.Teacher");
            //DropIndex("dbo.CourseItem", new[] { "Teacher_No" });
            //DropIndex("dbo.CourseItem", new[] { "Classroom_No" });
            //DropColumn("dbo.Store", "MemberInCnt");
            //DropColumn("dbo.CourseItem", "Teacher_No");
            //DropColumn("dbo.CourseItem", "Classroom_No");
            //CreateIndex("dbo.Course to Classroom", "Course_No");
            //CreateIndex("dbo.Course to Classroom", "Classroom_No");
            //CreateIndex("dbo.Course to Teacher", "Teacher_No");
            //CreateIndex("dbo.Course to Teacher", "Course_No");
            //AddForeignKey("dbo.Course to Classroom", "Course_No", "dbo.Course", "CourseNo", cascadeDelete: true);
            //AddForeignKey("dbo.Course to Classroom", "Classroom_No", "dbo.Classroom", "ClassroomNo", cascadeDelete: true);
            //AddForeignKey("dbo.Course to Teacher", "Teacher_No", "dbo.Teacher", "TeacherNo", cascadeDelete: true);
            //AddForeignKey("dbo.Course to Teacher", "Course_No", "dbo.Course", "CourseNo", cascadeDelete: true);
        }
    }
}
