namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.MemberCourse", new[] { "CourseSeries_No" });
            //RenameColumn(table: "dbo.MemberCourse", name: "CourseSeries_No", newName: "CourseSeries_CourseSeriesNo");
            //AddColumn("dbo.MemberCourse", "Num", c => c.Int(nullable: false));
            //AddColumn("dbo.MemberCourse", "CourseType_No", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddColumn("dbo.MemberCourse", "CourseType_CourseNo", c => c.String(maxLength: 50, unicode: false));
            //AlterColumn("dbo.MemberCourse", "CourseSeries_CourseSeriesNo", c => c.String(maxLength: 50, unicode: false));
            //CreateIndex("dbo.MemberCourse", "CourseType_CourseNo");
            //CreateIndex("dbo.MemberCourse", "CourseSeries_CourseSeriesNo");
            //AddForeignKey("dbo.MemberCourse", "CourseType_CourseNo", "dbo.CourseType", "CourseNo");
            //DropColumn("dbo.MemberCourse", "PayStatus");
            //DropColumn("dbo.MemberCourse", "PurchaseDate");
            //DropColumn("dbo.MemberCourse", "NumberOfCourse");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.MemberCourse", "NumberOfCourse", c => c.Int(nullable: false));
            //AddColumn("dbo.MemberCourse", "PurchaseDate", c => c.DateTime(nullable: false));
            //AddColumn("dbo.MemberCourse", "PayStatus", c => c.Boolean(nullable: false));
            //DropForeignKey("dbo.MemberCourse", "CourseType_CourseNo", "dbo.CourseType");
            //DropIndex("dbo.MemberCourse", new[] { "CourseSeries_CourseSeriesNo" });
            //DropIndex("dbo.MemberCourse", new[] { "CourseType_CourseNo" });
            //AlterColumn("dbo.MemberCourse", "CourseSeries_CourseSeriesNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //DropColumn("dbo.MemberCourse", "CourseType_CourseNo");
            //DropColumn("dbo.MemberCourse", "CourseType_No");
            //DropColumn("dbo.MemberCourse", "Num");
            //RenameColumn(table: "dbo.MemberCourse", name: "CourseSeries_CourseSeriesNo", newName: "CourseSeries_No");
            //CreateIndex("dbo.MemberCourse", "CourseSeries_No");
        }
    }
}
