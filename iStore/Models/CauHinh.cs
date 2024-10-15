namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHinh")]
    public partial class CauHinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CauHinh()
        {
            Chitiet_Cauhinh = new HashSet<Chitiet_Cauhinh>();
        }

        [Key]
        public int id_cauhinh { get; set; }

        [Required]
        [StringLength(100)]
        public string ten_cauhinh { get; set; }

        [Required]
        [StringLength(255)]
        public string giatri_cauhinh { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiet_Cauhinh> Chitiet_Cauhinh { get; set; }
    }
}
