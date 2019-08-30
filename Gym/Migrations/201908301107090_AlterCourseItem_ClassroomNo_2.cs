namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCourseItem_ClassroomNo_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseItem", "Classroom_No", 
                c => c.String(
                    nullable: false,
                    maxLength: 50,
                    fixedLength: false,
                    unicode: true,
                    storeType:"varchar"
                    )); 
            AddForeignKey("dbo.CourseItem", "Classroom_No", "dbo.Classroom", "ClassroomNo");

        }

        public override void Down()
        {
            DropForeignKey("dbo.CourseItem", "Classroom_No", "dbo.Classroom");
            AlterColumn("dbo.CourseItem", "Classroom_No", c => c.String());
        }
    }
}
