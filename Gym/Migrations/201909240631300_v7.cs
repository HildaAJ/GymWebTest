namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.MemberCourse", "CourseSeries_No", "dbo.CourseSeries");
            //DropForeignKey("dbo.Course", "CourseType_No", "dbo.CourseType");
            //DropForeignKey("dbo.CourseSeriesDetail", "CourseType_No", "dbo.CourseType");
            //DropIndex("dbo.MemberCourse", new[] { "CourseSeries_No" });
            //DropPrimaryKey("dbo.CourseType");
            //DropPrimaryKey("dbo.MemberCourse");
            //CreateTable(
            //    "dbo.BookingCourse",
            //    c => new
            //        {
            //            BookingCourseNo = c.Int(nullable: false, identity: true),
            //            Course_No = c.Int(nullable: false),
            //            Member_No = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.BookingCourseNo)
            //    .ForeignKey("dbo.Course", t => t.Course_No)
            //    .ForeignKey("dbo.Member", t => t.Member_No)
            //    .Index(t => t.Course_No)
            //    .Index(t => t.Member_No);
            
            //CreateTable(
            //    "dbo.PurchaseRecord",
            //    c => new
            //        {
            //            PurchaseRecordNo = c.Int(nullable: false, identity: true),
            //            Date = c.DateTime(nullable: false),
            //            Count = c.Int(nullable: false),
            //            PayStatus = c.Boolean(),
            //            CourseSeries_No = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Member_No = c.Int(),
            //        })
            //    .PrimaryKey(t => t.PurchaseRecordNo)
            //    .ForeignKey("dbo.CourseSeries", t => t.CourseSeries_No)
            //    .ForeignKey("dbo.Member", t => t.Member_No)
            //    .Index(t => t.CourseSeries_No)
            //    .Index(t => t.Member_No);
            
            //AddColumn("dbo.CourseType", "CourseTypeNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddColumn("dbo.MemberCourse", "Num", c => c.Int(nullable: false));
            //AddColumn("dbo.MemberCourse", "CourseType_no", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AlterColumn("dbo.MemberCourse", "MemberCourseNo", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.CourseType", "CourseTypeNo");
            //AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
            //CreateIndex("dbo.MemberCourse", "CourseType_no");
            //AddForeignKey("dbo.MemberCourse", "CourseType_no", "dbo.CourseType", "CourseTypeNo");
            //AddForeignKey("dbo.Course", "CourseType_No", "dbo.CourseType", "CourseTypeNo");
            //AddForeignKey("dbo.CourseSeriesDetail", "CourseType_No", "dbo.CourseType", "CourseTypeNo");
            //DropColumn("dbo.CourseType", "CourseNo");
            //DropColumn("dbo.MemberCourse", "CourseSeries_No");
            //DropColumn("dbo.MemberCourse", "PayStatus");
            //DropColumn("dbo.MemberCourse", "PurchaseDate");
            //DropColumn("dbo.MemberCourse", "NumberOfCourse");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.MemberCourse", "NumberOfCourse", c => c.Int(nullable: false));
            //AddColumn("dbo.MemberCourse", "PurchaseDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.MemberCourse", "PayStatus", c => c.Boolean(nullable: false));
            //AddColumn("dbo.MemberCourse", "CourseSeries_No", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddColumn("dbo.CourseType", "CourseNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //DropForeignKey("dbo.CourseSeriesDetail", "CourseType_No", "dbo.CourseType");
            //DropForeignKey("dbo.Course", "CourseType_No", "dbo.CourseType");
            //DropForeignKey("dbo.PurchaseRecord", "Member_No", "dbo.Member");
            //DropForeignKey("dbo.MemberCourse", "CourseType_no", "dbo.CourseType");
            //DropForeignKey("dbo.PurchaseRecord", "CourseSeries_No", "dbo.CourseSeries");
            //DropForeignKey("dbo.BookingCourse", "Member_No", "dbo.Member");
            //DropForeignKey("dbo.BookingCourse", "Course_No", "dbo.Course");
            //DropIndex("dbo.PurchaseRecord", new[] { "Member_No" });
            //DropIndex("dbo.PurchaseRecord", new[] { "CourseSeries_No" });
            //DropIndex("dbo.MemberCourse", new[] { "CourseType_no" });
            //DropIndex("dbo.BookingCourse", new[] { "Member_No" });
            //DropIndex("dbo.BookingCourse", new[] { "Course_No" });
            //DropPrimaryKey("dbo.MemberCourse");
            //DropPrimaryKey("dbo.CourseType");
            //AlterColumn("dbo.MemberCourse", "MemberCourseNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //DropColumn("dbo.MemberCourse", "CourseType_no");
            //DropColumn("dbo.MemberCourse", "Num");
            //DropColumn("dbo.CourseType", "CourseTypeNo");
            //DropTable("dbo.PurchaseRecord");
            //DropTable("dbo.BookingCourse");
            //AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
            //AddPrimaryKey("dbo.CourseType", "CourseNo");
            //CreateIndex("dbo.MemberCourse", "CourseSeries_No");
            //AddForeignKey("dbo.CourseSeriesDetail", "CourseType_No", "dbo.CourseType", "CourseNo");
            //AddForeignKey("dbo.Course", "CourseType_No", "dbo.CourseType", "CourseNo");
            //AddForeignKey("dbo.MemberCourse", "CourseSeries_No", "dbo.CourseSeries", "CourseSeriesNo");
        }
    }
}
