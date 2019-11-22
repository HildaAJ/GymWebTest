namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnMemberCourse : DbMigration
    {
        public override void Up()
        {
            //«¬ºAVarchar unicode:false
            AddColumn("dbo.MemberCourse", "CourseType_no",
                c => c.String(
                    nullable: false,
                    maxLength: 50,
                    unicode:false
                    ));
            AddForeignKey("dbo.MemberCourse", "CourseType_no", "dbo.CourseType", "CourseTypeNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberCourse", "CourseType_no");
            DropColumn("dbo.MemberCourse", "CourseType_no");

        }
    }
}
