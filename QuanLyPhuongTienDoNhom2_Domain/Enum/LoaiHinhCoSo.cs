using System.ComponentModel;

namespace QuanLyPhuongTienDoNhom2_Domain.Enum
{
    public enum LoaiHinhCoSo : byte
    {
        [Description("Chưa xác định")]
        ChuaXacDinh = 0,
        [Description("Cơ sở sử dụng phương tiện đo")]
        SuDung = 1,
        [Description("Cơ sở sản xuất phương tiện đo")]
        SanXuat = 2,
        [Description("Cơ sở nhập khẩu phương tiện đo")]
        NhapKhau = 3,
        [Description("Cơ sở kinh doanh phương tiện đo")]
        ThuNghiem = 4

    }
}
