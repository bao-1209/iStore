namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuongThucThanhToan")]
    public partial class PhuongThucThanhToan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhuongThucThanhToan()
        {
            ThanhToans = new HashSet<ThanhToan>();
        }

        [Key]
        public int id_phuongthuc { get; set; }

        [Required]
        [StringLength(50)]
        public string ten_phuongthuc { get; set; }

        [Required]
        [StringLength(50)]
        public string sotaikhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string nganhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
