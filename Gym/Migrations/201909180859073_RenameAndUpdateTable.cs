namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAndUpdateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseSeries to course", "Num",
                c => c.Int(
                    nullable: false,
                    defaultValue: 1));

            RenameTable(name: "Course", newName: "CourseType");
            RenameTable(name: "CourseSeries to Course", newName: "CourseSeriesDetail");
            RenameTable(name: "CourseItem", newName:"Course");
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseSeries to course", "Num");

            RenameTable(name: "CourseType", newName: "Course");
            RenameTable(name: "CourseSeriesDetail", newName: "CourseSeries to Course");
            RenameTable(name: "Course", newName: "CourseItem");
        }
    }
}
