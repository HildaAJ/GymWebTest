namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseColumn_v3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Course", "Course_No", "CourseType_No");
            RenameColumn("dbo.CourseSeriesDetail", "Course_No", "CourseType_No");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Course", "CourseType_No", "Course_No");
            RenameColumn("dbo.CourseSeriesDetail", "CourseType_No", "Course_No");
        }
    }
}
