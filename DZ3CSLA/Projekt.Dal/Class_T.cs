//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UpravljanjeProjektima.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Class_T
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class_T()
        {
            this.Order_t = new HashSet<Order_t>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual Phylum_t Phylum_t { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_t> Order_t { get; set; }
    }
}
