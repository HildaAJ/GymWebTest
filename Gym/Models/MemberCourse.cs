namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberCourse")]
    public partial class MemberCourse
    {
        [Key]
        [StringLength(50)]
        public string MemberCourseNo { get; set; }

        public int Member_No { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string CourseSeries_No { get; set; }

        //public bool PayStatus { get; set; }

        //public DateTime PurchaseDate { get; set; }

        //public int NumberOfCourse { get; set; }

        public int Num { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseType_No { get; set; }

        //public virtual CourseSeries CourseSeries { get; set; }

        public virtual CourseType CourseType { get; set; }
        public virtual Member Member { get; set; }
    }
}
