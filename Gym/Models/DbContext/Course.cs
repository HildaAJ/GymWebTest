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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            BookingCourse = new HashSet<BookingCourse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseNo { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseType_No { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingCourse> BookingCourse { get; set; }

        public virtual Classroom Classroom { get; set; }

        public virtual CourseType CourseType { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
