namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.MemberCourse", "PK__MemberCo__B479B3579D30CEB0");
            //DropColumn("dbo.MemberCourse", "MemberCourseNo");
            //AddColumn("dbo.MemberCourse", "MemberCourseNo", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
        }

        public override void Down()
        {
            //DropPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
            //DropColumn("dbo.MemberCourse", "MemberCourseNo");
            //AddColumn("dbo.MemberCourse", "MemberCourseNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            //AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
        }
    }
}
