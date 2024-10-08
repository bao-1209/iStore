namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        public int id_danhgia { get; set; }

        public int? id_nguoidung { get; set; }

        public int? id_sanpham { get; set; }

        public int? sosao { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string noidung { get; set; }

        public DateTime? thoigian { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
