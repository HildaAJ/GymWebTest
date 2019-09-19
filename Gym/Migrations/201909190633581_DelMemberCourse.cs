namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelMemberCourse : DbMigration
    {
        public override void Up()
        {
            //§R°£CourseSeries_NoÄæ¦ì
            DropForeignKey("dbo.MemberCourse", "CourseSeries_No", "dbo.CourseSeries");
            
        }
        
        public override void Down()
        { 
            AddForeignKey("dbo.MemberCourse", "CourseSeries_No", "dbo.CourseSeries", "CourseSeriesNo");
        }
    }
}
