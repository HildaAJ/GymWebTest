namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreMemberInCnt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Store", "MemberInCnt",
                c => c.Int(
                    nullable: true,
                    identity: false,
                    defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Store", "MemberInCnt");
        }
    }
}
