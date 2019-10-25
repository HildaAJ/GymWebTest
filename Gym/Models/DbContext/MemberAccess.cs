namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberAccess")]
    public partial class MemberAccess
    {
        [Key]
        public int MemberAccessNo { get; set; }

        public int Member_No { get; set; }

        [Required]
        [StringLength(50)]
        public string Store_No { get; set; }

        public DateTime EnterTime { get; set; }

        public DateTime LeaveTime { get; set; }

        public virtual Member Member { get; set; }

        public virtual Store Store { get; set; }
    }
}
