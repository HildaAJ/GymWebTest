namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseColumn_v2 : DbMigration
    {
        public override void Up()
        {
            //�ק�Course��FK�W��  
            RenameColumn("dbo.CourseType", "CourseNo", "CourseTypeNo");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.CourseType", "CourseTypeNo", "CourseNo");
        }
    }
}
