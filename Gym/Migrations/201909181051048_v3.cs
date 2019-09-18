namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.Course", name: "Course_No", newName: "CourseType_No");
            //RenameColumn(table: "dbo.CourseSeriesDetail", name: "Course_No", newName: "CourseType_No");
            //RenameIndex(table: "dbo.Course", name: "IX_Course_No", newName: "IX_CourseType_No");
            //RenameIndex(table: "dbo.CourseSeriesDetail", name: "IX_Course_No", newName: "IX_CourseType_No");
            //DropPrimaryKey("dbo.Course");
            //AddColumn("dbo.Course", "CourseNo", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.Course", "CourseNo");
            //DropColumn("dbo.Course", "CourseItemNo");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Course", "CourseItemNo", c => c.Int(nullable: false));
            //DropPrimaryKey("dbo.Course");
            //DropColumn("dbo.Course", "CourseNo");
            //AddPrimaryKey("dbo.Course", "CourseItemNo");
            //RenameIndex(table: "dbo.CourseSeriesDetail", name: "IX_CourseType_No", newName: "IX_Course_No");
            //RenameIndex(table: "dbo.Course", name: "IX_CourseType_No", newName: "IX_Course_No");
            //RenameColumn(table: "dbo.CourseSeriesDetail", name: "CourseType_No", newName: "Course_No");
            //RenameColumn(table: "dbo.Course", name: "CourseType_No", newName: "Course_No");
        }
    }
}
