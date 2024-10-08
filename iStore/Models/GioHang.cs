namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GioHang()
        {
            Chitiet_Giohang = new HashSet<Chitiet_Giohang>();
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int id_giohang { get; set; }

        public int? id_nguoidung { get; set; }

        public int? id_magiamgia { get; set; }

        public decimal tongtien { get; set; }

        [StringLength(50)]
        public string ma_giamgia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiet_Giohang> Chitiet_Giohang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual MaGiamGia MaGiamGia { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
