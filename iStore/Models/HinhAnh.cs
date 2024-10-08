namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnh")]
    public partial class HinhAnh
    {
        [Key]
        public int id_hinhanh { get; set; }

        public int? id_sanpham { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string url_hinhanh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
