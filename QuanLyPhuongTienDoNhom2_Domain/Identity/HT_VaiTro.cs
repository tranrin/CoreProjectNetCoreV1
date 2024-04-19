using Microsoft.AspNetCore.Identity;

namespace QuanLyPhuongTienDoNhom2_Domain.Identity
{
    public class HT_VaiTro : IdentityRole<Guid>
    {
        //public Int16 MaVaiTro { get; set; }
        //public string TenVaiTro { get; set; }
        public string MoTa { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
