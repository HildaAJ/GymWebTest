namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCourseItem : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE dbo.CourseItem DROP CONSTRAINT PK__CourseIt__FC92384A0E63E549");
            DropPrimaryKey("dbo.CourseItem", "PK__CourseIt__FC92384A0E63E549");
            AlterColumn("dbo.CourseItem", "CourseItemNo",
                c => c.Int(
                    nullable: false,
                    identity: true
                    ));
            AddPrimaryKey("dbo.CourseItem", "CourseItemNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CourseItem", "CourseItemNo");
            AlterColumn("dbo.CourseItem", "CourseItemNo",
                c => c.String(
                    nullable: false,
                    maxLength:50,
                    fixedLength:false,
                    unicode:true,
                    storeType:"varchar"
                    ));
            AddPrimaryKey("dbo.CourseItem", "CourseItemNo");
        }
    }
}
