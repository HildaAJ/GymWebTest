namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingCourse")]
    public partial class BookingCourse
    {
        [Key]
        public int BookingCourseNo { get; set; }

        public int Course_No { get; set; }

        public int Member_No { get; set; }

        public virtual Course Course { get; set; }

        public virtual Member Member { get; set; }
    }
}
