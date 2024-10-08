namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            Chitiet_Cauhinh = new HashSet<Chitiet_Cauhinh>();
            Chitiet_Donhang = new HashSet<Chitiet_Donhang>();
            Chitiet_Giohang = new HashSet<Chitiet_Giohang>();
            DanhGias = new HashSet<DanhGia>();
            HinhAnhs = new HashSet<HinhAnh>();
        }

        [Key]
        public int id_sanpham { get; set; }

        public int? id_danhmuc { get; set; }

        public int? id_thuonghieu { get; set; }

        [Required]
        [StringLength(255)]
        public string ten_sanpham { get; set; }

        public decimal gia_sanpham { get; set; }

        public int soluong { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiet_Cauhinh> Chitiet_Cauhinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiet_Donhang> Chitiet_Donhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiet_Giohang> Chitiet_Giohang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnh> HinhAnhs { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
