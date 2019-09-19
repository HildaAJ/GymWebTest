namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKPurchaseRec : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.PurchaseRecord", "CourseSeries_No", "dbo.CourseSeries", "CourseSeriesNo");
            AddForeignKey("dbo.PurchaseRecord", "Member_No", "dbo.Member", "MemberNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRecord", "CourseSeries_No");
            DropForeignKey("dbo.PurchaseRecord", "Member_No");
        }
    }
}
