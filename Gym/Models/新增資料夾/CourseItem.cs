namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [Key]
        //[StringLength(50)]
        //public string CourseItemNo { get; set; }
        public int CourseItemNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Course_No { get; set; }

        public int MemberAvailable { get; set; }

        [Column(TypeName = "date")]
        public DateTime ClassDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Classroom_No { get; set; }

        [Required]
        [StringLength(50)]
        public string Teacher_No { get; set; }

        public virtual Classroom Classroom { get; set; }

        public virtual CourseType CourseType { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
