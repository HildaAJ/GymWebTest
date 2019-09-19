namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CourseSeries
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseSeries()
        {
            CourseSeriesDetail = new HashSet<CourseSeriesDetail>();
            PurchaseRecord = new HashSet<PurchaseRecord>();
        }

        [Key]
        [StringLength(50)]
        public string CourseSeriesNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool SaleEnable { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseInfo { get; set; }

        public DateTime DeadLine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseSeriesDetail> CourseSeriesDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseRecord> PurchaseRecord { get; set; }
    }
}
