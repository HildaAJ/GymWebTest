namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseColumn_v2 : DbMigration
    {
        public override void Up()
        {
            //­×§ïCourseªºFK¦WºÙ  
            RenameColumn("dbo.CourseType", "CourseNo", "CourseTypeNo");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.CourseType", "CourseTypeNo", "CourseNo");
        }
    }
}
