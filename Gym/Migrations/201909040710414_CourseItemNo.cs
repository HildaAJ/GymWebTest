namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseItemNo : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CourseItem");
            AlterColumn("dbo.CourseItem", "CourseItemNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CourseItem", "CourseItemNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CourseItem");
            AlterColumn("dbo.CourseItem", "CourseItemNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddPrimaryKey("dbo.CourseItem", "CourseItemNo");
        }
    }
}
