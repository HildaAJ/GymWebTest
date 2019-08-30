namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCourseItem_ClassroomNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseItem", "Classroom_No", c => c.String());
            

        }
        
        public override void Down()
        { 
            AlterColumn("dbo.CourseItem", "Classroom_No", c => c.String(nullable: false,
                    maxLength: 50,
                    fixedLength: false,
                    unicode: true));
        }
    }
}
