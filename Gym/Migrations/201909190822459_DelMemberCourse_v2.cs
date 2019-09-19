namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelMemberCourse_v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MemberCourse", "CourseSeries_No");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberCourse", "CourseSeries_No",
                c => c.String(
                nullable: false,
                unicode: true,
                maxLength: 50
                ));
            AddForeignKey("dbo.MemberCourse", "CourseSeries_No", "dbo.CourseSeries", "CourseSeriesNo");
        }
    }
}
