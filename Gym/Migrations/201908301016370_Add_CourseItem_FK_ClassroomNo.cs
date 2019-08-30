namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CourseItem_FK_ClassroomNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseItem", "Classroom_No",
                c => c.String(
                    nullable:false,
                    maxLength:50,
                    fixedLength:false,
                    unicode:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseItem", "Classroom_No");
        }
    }
}
