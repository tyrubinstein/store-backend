//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cloth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cloth()
        {
            this.Inventories = new HashSet<Inventory>();
        }
    
        public int ClothID { get; set; }
        public int ClothCompaniCod { get; set; }
        public int CompanyId { get; set; }
        public string Describe { get; set; }
        public string pictureURL { get; set; }
        public string Color { get; set; }
        public Nullable<int> Price { get; set; }
        public string SizesRange { get; set; }
        public Nullable<int> YearOfProduction { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
