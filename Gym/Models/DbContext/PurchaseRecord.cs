namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseRecord")]
    public partial class PurchaseRecord
    {
        [Key]
        public int PurchaseRecordNo { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public bool? PayStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseSeries_No { get; set; }

        public int? Member_No { get; set; }

        public virtual CourseSeries CourseSeries { get; set; }

        public virtual Member Member { get; set; }
    }
}
