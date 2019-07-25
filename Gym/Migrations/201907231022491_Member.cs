namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Member : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "Name",
                c => c.String(
                    nullable: false,
                    maxLength: 50,
                    fixedLength: false,
                    unicode: true));
            
        }
        
        public override void Down()
        {
            DropColumn("Gym.Member", "Name");
        }
    }
}
