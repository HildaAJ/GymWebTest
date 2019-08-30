namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CourseItem_FK_TeacherNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseItem", "Teacher_No",
                c => c.String());
            

        }

        public override void Down()
        {
            DropColumn("dbo.CourseItem", "Teacher_No");
        }
    }
}
