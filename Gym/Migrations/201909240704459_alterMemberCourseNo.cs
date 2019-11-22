namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterMemberCourseNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MemberCourse","MemberCourseNo",
              c=>c.Int(
                 identity:true,
                 nullable:false                 
              ));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MemberCourse", "MemberCourseNo",
              c => c.Int(
                 identity: false,
                 nullable: false
              ));
        }
    }
}
