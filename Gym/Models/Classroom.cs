namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classroom")]
    public partial class Classroom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classroom()
        {
            CourseItem = new HashSet<Course>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [StringLength(50)]
        public string ClassroomNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Store_No { get; set; }

        public virtual Store Store { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> CourseItem { get; set; }
    }
}
