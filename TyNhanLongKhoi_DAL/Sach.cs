namespace TyNhanLongKhoi_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            ChiTietPhieuMuons = new HashSet<ChiTietPhieuMuon>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [StringLength(10)]
        public string MaTacGia { get; set; }

        [StringLength(10)]
        public string MaNXB { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [StringLength(20)]
        public string TheLoai { get; set; }

        [StringLength(10)]
        public string NamXB { get; set; }

        public int SoLuong { get; set; }

        public virtual NhaXB NhaXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
