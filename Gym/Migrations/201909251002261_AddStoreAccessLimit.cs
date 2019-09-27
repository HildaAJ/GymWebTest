namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreAccessLimit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Store", "AccessLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Store", "AccessLimit");
        }
    }
}
