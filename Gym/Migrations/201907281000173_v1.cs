namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.__MigrationHistory",
            //    c => new
            //        {
            //            MigrationId = c.String(nullable: false, maxLength: 150),
            //            ContextKey = c.String(nullable: false, maxLength: 300),
            //            Model = c.Binary(nullable: false),
            //            ProductVersion = c.String(nullable: false, maxLength: 32),
            //        })
            //    .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            //AlterColumn("dbo.Member", "Sex", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Member", "Sex", c => c.String(nullable: false, maxLength: 10, unicode: false));
            //DropTable("dbo.__MigrationHistory");
        }
    }
}
