namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseItem")]
    public partial class CourseItem
    {
        [Key]
        [StringLength(50)]
        public string CourseItemNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Course_No { get; set; }

        public int MemberAvailable { get; set; }

        [Column(TypeName = "date")]
        public DateTime ClassDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual Course Course { get; set; }
    }
}
