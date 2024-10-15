namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chitiet_Cauhinh
    {
        [Key]
        public int id_ctcauhinh { get; set; }

        public int? id_sanpham { get; set; }

        public int? id_cauhinh { get; set; }

        [Required]
        [StringLength(255)]
        public string giatri { get; set; }

        public virtual CauHinh CauHinh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
