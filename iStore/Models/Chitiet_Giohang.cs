namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chitiet_Giohang
    {
        [Key]
        public int id_ctgiohang { get; set; }

        public int? id_giohang { get; set; }

        public int? id_sanpham { get; set; }

        public int soluong { get; set; }

        public decimal gia { get; set; }

        public virtual GioHang GioHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
