namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKBooking : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookingCourse", "Course_No",
                c => c.Int(nullable:false));
            AddForeignKey("dbo.BookingCourse", "Course_No", "dbo.Course", "CourseNo");
            AddForeignKey("dbo.BookingCourse", "Member_No", "dbo.Member", "MemberNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingCourse", "Course_No");
            DropForeignKey("dbo.BookingCourse", "Member_No");
        }
    }
}
