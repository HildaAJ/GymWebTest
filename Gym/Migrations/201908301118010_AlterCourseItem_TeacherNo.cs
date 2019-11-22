namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCourseItem_TeacherNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseItem", "Teacher_No",
                c => c.String(
                    nullable: false,
                    maxLength: 50,
                    fixedLength: false,
                    unicode: true,
                    storeType: "varchar"
                    ));
            AddForeignKey("dbo.CourseItem", "Teacher_No", "dbo.Teacher", "TeacherNo");

        }

        public override void Down()
        {
            DropForeignKey("dbo.CourseItem", "Teacher_No", "dbo.Teacher");
            AlterColumn("dbo.CourseItem", "Teacher_No", c => c.String());
        }
    }
}
