namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMemberCourse : DbMigration
    {
        public override void Up()
        {

            DropColumn("dbo.MemberCourse", "PayStatus");
            DropColumn("dbo.MemberCourse", "PurchaseDate");
            RenameColumn("dbo.MemberCourse", name: "NumberOfCourse", newName: "Num");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberCourse", "PayStatus",c=>c.Boolean(defaultValue:true));
            AddColumn("dbo.MemberCourse", "PurchaseDate", c => c.DateTime());
            RenameColumn("dbo.MemberCourse", name: "Num", newName: "NumberOfCourse");
   
        }
    }
}
