namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterCourseColumn : DbMigration
    {
        public override void Up()
        {
            //�ק�Course��PK�W��  
            RenameColumn("dbo.Course", "CourseItemNo", "CourseNo");
            
        }
        
        public override void Down()
        {
           RenameColumn("dbo.Course", "CourseNo", "CourseItemNo");
            
        }
    }
}
