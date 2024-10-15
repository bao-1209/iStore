namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            DanhGias = new HashSet<DanhGia>();
            DonHangs = new HashSet<DonHang>();
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        public int id_nguoidung { get; set; }

        public int? id_vaitro { get; set; }

        [Required]
        [StringLength(50)]
        public string ten_nguoidung { get; set; }

        [Required]
        [StringLength(255)]
        public string hoten { get; set; }

        [Required]
        [StringLength(255)]
        public string matkhau { get; set; }

        [Required]
        [StringLength(255)]
        public string matkhau_kiemtra { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(12)]
        public string sdt { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual VaiTro VaiTro { get; set; }
    }
}
