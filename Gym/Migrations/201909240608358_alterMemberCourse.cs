namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterMemberCourse : DbMigration
    {
        public override void Up()
        {
            
            DropPrimaryKey("dbo.MemberCourse", "PK__MemberCo__B479B3579D30CEB0");
            AlterColumn("dbo.MemberCourse", "MemberCourseNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
            AlterColumn("dbo.MemberCourse", "MemberCourseNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
        }
    }
}
