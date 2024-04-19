using Microsoft.AspNetCore.Identity;

namespace QuanLyPhuongTienDoNhom2_Domain.Identity
{
    public class HT_NguoiDung : IdentityUser<Guid>
    {
        //int MaNguoiDung
        public Guid MaToChuc { get; set; }
        //public string HoTen { get; set; } userName
        //public string DiaChi { get; set; } Adress
        //public string HopThu { get; set; } Email
        //public string DienThoai { get; set; } PhoneNumber
        //public string TenDangNhap { get; set; } Account
        //public string MatKhau { get; set; } Password
        //public DateTime NgayTao { get; set; } CreatedAt
        //public DateTime? NgayKhoa { get; set; } LockedAt
        //public DateTime? NgayHetHan { get; set; } ExpiredAt
        //public string GhiChu { get; set; } Note
    }
}
