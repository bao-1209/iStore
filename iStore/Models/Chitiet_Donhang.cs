namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chitiet_Donhang
    {
        [Key]
        public int id_ctdonhang { get; set; }

        public int? id_donhang { get; set; }

        public int? id_sanpham { get; set; }

        public int soluong { get; set; }

        public decimal gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
