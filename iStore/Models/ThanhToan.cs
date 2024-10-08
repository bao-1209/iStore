namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhToan")]
    public partial class ThanhToan
    {
        [Key]
        public int id_thanhtoan { get; set; }

        public int? id_phuongthuc { get; set; }

        public int? id_donhang { get; set; }

        public decimal sotien { get; set; }

        public DateTime? ngay_tao { get; set; }

        public DateTime? ngay_xacnhan { get; set; }

        [Required]
        [StringLength(255)]
        public string magiadich { get; set; }

        [Required]
        [StringLength(255)]
        public string trangthai { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }
    }
}
