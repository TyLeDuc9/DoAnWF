namespace TyNhanLongKhoi_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuThu")]
    public partial class ThuThu
    {
        [Key]
        [StringLength(15)]
        public string MaThuThu { get; set; }

        [StringLength(50)]
        public string TenThuThu { get; set; }
    }
}
