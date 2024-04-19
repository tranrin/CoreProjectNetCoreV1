using System.ComponentModel;

namespace QuanLyPhuongTienDoNhom2_Domain.Enum
{
    enum LoaiHinhHoatDong : byte
    {
        [Description("Chưa xác định")]
        ChuaXacDinh = 0,
        [Description("Kiểm định")]
        KiemDinh = 1,
        [Description("Hiệu chuẩn")]
        HieuChuan = 2,
        [Description("Thử nghiệm")]
        ThuNghiem = 3
    }


}
