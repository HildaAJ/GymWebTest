//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gym.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.MemberAccess = new HashSet<MemberAccess>();
            this.MemberCourse = new HashSet<MemberCourse>();
            this.Store = new HashSet<Store>();
        }
    
        public string MemberNo { get; set; }
        public string Email { get; set; }
        public System.DateTime Birthday { get; set; }
        public string Tel { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public string PassWay { get; set; }
        public string Role_No { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime LastLoginTime { get; set; }
        public bool IsLogin { get; set; }
        public bool Status { get; set; }
    
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberAccess> MemberAccess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberCourse> MemberCourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store> Store { get; set; }
    }
}
