namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            //新增BookingCourse 會員預約課程
            CreateTable(
                "dbo.BookingCourse",
                c => new
                {
                    BookingCourseNo = c.Int(nullable: false, identity: true),
                    Course_No = c.String(nullable: false, unicode: false, maxLength: 50),
                    Member_No = c.Int(nullable: false)
                })
                .PrimaryKey(t => t.BookingCourseNo);
            //新增PurchaseRecord 方案購買紀錄
            CreateTable(
                "dbo.PurchaseRecord",
                c => new
                {
                    PurchaseRecordNo = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    Count = c.Int(nullable: false),
                    PayStatus = c.Boolean(),
                    CourseSeries_No = c.String(nullable: false, unicode: false, maxLength: 50),
                    Member_No = c.Int()
                })
                .PrimaryKey(t => t.PurchaseRecordNo);
        }
        
        public override void Down()
        {
            DropTable("dbo.BookingCourse");
            DropTable("dbo.PurchaseRecord");
        }
    }
}
