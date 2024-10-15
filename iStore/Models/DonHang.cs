namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            Chitiet_Donhang = new HashSet<Chitiet_Donhang>();
            ThanhToans = new HashSet<ThanhToan>();
        }

        [Key]
        public int id_donhang { get; set; }

        public int? id_nguoidung { get; set; }

        public int? id_magiamgia { get; set; }

        public int? id_giohang { get; set; }

        public DateTime? thoigian_dathang { get; set; }

        [Required]
        [StringLength(255)]
        public string trangthai { get; set; }

        public decimal tongtien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiet_Donhang> Chitiet_Donhang { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual MaGiamGia MaGiamGia { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
