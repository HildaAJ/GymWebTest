namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.CourseItem", "Course_No", "dbo.Course");
            //DropForeignKey("dbo.CourseSeries to Course", "Course_No", "dbo.Course");
            //DropForeignKey("dbo.CourseSeries to Course", "CourseSeries_No", "dbo.CourseSeries");
            //DropForeignKey("dbo.CourseItem", "Teacher_No", "dbo.Teacher");
            //DropForeignKey("dbo.CourseItem", "Classroom_No", "dbo.Classroom");
            //DropIndex("dbo.CourseItem", new[] { "Course_No" });
            //DropIndex("dbo.CourseItem", new[] { "Classroom_No" });
            //DropIndex("dbo.CourseItem", new[] { "Teacher_No" });
            //DropIndex("dbo.CourseSeries to Course", new[] { "Course_No" });
            //DropIndex("dbo.CourseSeries to Course", new[] { "CourseSeries_No" });
            //DropPrimaryKey("dbo.Course");
            //CreateTable(
            //    "dbo.CourseType",
            //    c => new
            //        {
            //            CourseNo = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Name = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.CourseNo);
            
            //CreateTable(
            //    "dbo.CourseSeriesDetail",
            //    c => new
            //        {
            //            CourseSeries_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Course_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Num = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.CourseSeries_No, t.Course_No })
            //    .ForeignKey("dbo.CourseSeries", t => t.CourseSeries_No)
            //    .ForeignKey("dbo.CourseType", t => t.Course_No)
            //    .Index(t => t.CourseSeries_No)
            //    .Index(t => t.Course_No);
            
            //AddColumn("dbo.Course", "CourseItemNo", c => c.Int(nullable: false));
            //AddColumn("dbo.Course", "Course_No", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddColumn("dbo.Course", "MemberAvailable", c => c.Int(nullable: false));
            //AddColumn("dbo.Course", "ClassDate", c => c.DateTime(nullable: false, storeType: "date"));
            //AddColumn("dbo.Course", "StartTime", c => c.DateTime(nullable: false));
            //AddColumn("dbo.Course", "EndTime", c => c.DateTime(nullable: false));
            //AddColumn("dbo.Course", "Classroom_No", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddColumn("dbo.Course", "Teacher_No", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddPrimaryKey("dbo.Course", "CourseItemNo");
            //CreateIndex("dbo.Course", "Course_No");
            //CreateIndex("dbo.Course", "Classroom_No");
            //CreateIndex("dbo.Course", "Teacher_No");
            //AddForeignKey("dbo.Course", "Course_No", "dbo.CourseType", "CourseNo");
            //AddForeignKey("dbo.Course", "Teacher_No", "dbo.Teacher", "TeacherNo");
            //AddForeignKey("dbo.Course", "Classroom_No", "dbo.Classroom", "ClassroomNo");
            //DropColumn("dbo.Course", "CourseNo");
            //DropColumn("dbo.Course", "Name");
            //DropTable("dbo.CourseItem");
            //DropTable("dbo.CourseSeries to Course");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.CourseSeries to Course",
            //    c => new
            //        {
            //            Course_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            CourseSeries_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //        })
            //    .PrimaryKey(t => new { t.Course_No, t.CourseSeries_No });
            
            //CreateTable(
            //    "dbo.CourseItem",
            //    c => new
            //        {
            //            CourseItemNo = c.Int(nullable: false, identity: true),
            //            Course_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            MemberAvailable = c.Int(nullable: false),
            //            ClassDate = c.DateTime(nullable: false, storeType: "date"),
            //            StartTime = c.DateTime(nullable: false),
            //            EndTime = c.DateTime(nullable: false),
            //            Classroom_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Teacher_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //        })
            //    .PrimaryKey(t => t.CourseItemNo);
            
            //AddColumn("dbo.Course", "Name", c => c.String(nullable: false, maxLength: 50));
            //AddColumn("dbo.Course", "CourseNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //DropForeignKey("dbo.Course", "Classroom_No", "dbo.Classroom");
            //DropForeignKey("dbo.Course", "Teacher_No", "dbo.Teacher");
            //DropForeignKey("dbo.CourseSeriesDetail", "Course_No", "dbo.CourseType");
            //DropForeignKey("dbo.CourseSeriesDetail", "CourseSeries_No", "dbo.CourseSeries");
            //DropForeignKey("dbo.Course", "Course_No", "dbo.CourseType");
            //DropIndex("dbo.CourseSeriesDetail", new[] { "Course_No" });
            //DropIndex("dbo.CourseSeriesDetail", new[] { "CourseSeries_No" });
            //DropIndex("dbo.Course", new[] { "Teacher_No" });
            //DropIndex("dbo.Course", new[] { "Classroom_No" });
            //DropIndex("dbo.Course", new[] { "Course_No" });
            //DropPrimaryKey("dbo.Course");
            //DropColumn("dbo.Course", "Teacher_No");
            //DropColumn("dbo.Course", "Classroom_No");
            //DropColumn("dbo.Course", "EndTime");
            //DropColumn("dbo.Course", "StartTime");
            //DropColumn("dbo.Course", "ClassDate");
            //DropColumn("dbo.Course", "MemberAvailable");
            //DropColumn("dbo.Course", "Course_No");
            //DropColumn("dbo.Course", "CourseItemNo");
            //DropTable("dbo.CourseSeriesDetail");
            //DropTable("dbo.CourseType");
            //AddPrimaryKey("dbo.Course", "CourseNo");
            //CreateIndex("dbo.CourseSeries to Course", "CourseSeries_No");
            //CreateIndex("dbo.CourseSeries to Course", "Course_No");
            //CreateIndex("dbo.CourseItem", "Teacher_No");
            //CreateIndex("dbo.CourseItem", "Classroom_No");
            //CreateIndex("dbo.CourseItem", "Course_No");
            //AddForeignKey("dbo.CourseItem", "Classroom_No", "dbo.Classroom", "ClassroomNo");
            //AddForeignKey("dbo.CourseItem", "Teacher_No", "dbo.Teacher", "TeacherNo");
            //AddForeignKey("dbo.CourseSeries to Course", "CourseSeries_No", "dbo.CourseSeries", "CourseSeriesNo", cascadeDelete: true);
            //AddForeignKey("dbo.CourseSeries to Course", "Course_No", "dbo.Course", "CourseNo", cascadeDelete: true);
            //AddForeignKey("dbo.CourseItem", "Course_No", "dbo.Course", "CourseNo");
        }
    }
}
