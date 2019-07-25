namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMemberGender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Member", "Sex",
                c => c.String(
                    maxLength: 50,
                    nullable:false,
                    unicode:true,
                    fixedLength:false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Member", "Sex",
                c => c.String(
                    maxLength: 10,
                    nullable: false,
                    unicode: true,
                    fixedLength: false));
        }
    }
}
