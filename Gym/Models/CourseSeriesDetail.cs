namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseSeriesDetail")]
    public partial class CourseSeriesDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CourseSeries_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Course_No { get; set; }

        public int Num { get; set; }

        public virtual CourseSeries CourseSeries { get; set; }

        public virtual CourseType CourseType { get; set; }
    }
}
