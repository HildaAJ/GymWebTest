namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberCourseNoPK : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MemberCourse");
            DropColumn("dbo.MemberCourse", "MemberCourseNo");
            AddColumn("dbo.MemberCourse", "MemberCourseNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.MemberCourse");
            DropColumn("dbo.MemberCourse", "MemberCourseNo");
            AddColumn("dbo.MemberCourse", "MemberCourseNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddPrimaryKey("dbo.MemberCourse", "MemberCourseNo");
        }
    }
}
