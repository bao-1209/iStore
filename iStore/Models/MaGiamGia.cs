namespace iStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaGiamGia")]
    public partial class MaGiamGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaGiamGia()
        {
            DonHangs = new HashSet<DonHang>();
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        public int id_magiamgia { get; set; }

        [Required]
        [StringLength(50)]
        public string ma_giamgia { get; set; }

        public decimal giatri_giam { get; set; }

        [Required]
        [StringLength(20)]
        public string loai_giam { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_batdau { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_ketthuc { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string dieukien { get; set; }

        public int soluot_sudung { get; set; }

        public int soluot_conlai { get; set; }

        public bool trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}
