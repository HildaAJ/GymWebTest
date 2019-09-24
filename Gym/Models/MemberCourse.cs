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
        //[Key]
        //[StringLength(50)]
        //public string MemberCourseNo { get; set; }

        [Key] 
        public int MemberCourseNo { get; set; }

        public int Member_No { get; set; }

        public int Num { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseType_no { get; set; }

        public virtual CourseType CourseType { get; set; }

        public virtual Member Member { get; set; }
    }
}
