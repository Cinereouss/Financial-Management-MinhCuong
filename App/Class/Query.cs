using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhCuong.Class
{
    class Query : BaseDao
    {
        public DataTable DataTable { get; private set; }

        public Query() : base(Program.strConnection)
        {
        }

        public int GetIdNewRecord(string table)
        {
            string[] cols = { "MAX(Id)" };
            string[] conditions = { };
            MySqlParameter[] parameters = { };
            DataTable dataTable = Select(table, cols, conditions, parameters);
            DataRow row = dataTable.Rows[0]; 
            return Convert.ToInt32(row["MAX(Id)"].ToString());
        }

        public int AddChungTu(string NguoiCt)
        {
            string[] cols = {"NguoiChungTu", "NgayChungTu"};
            string[] conditions = {"@NguoiChungTu", "@NgayChungTu" };
            MySqlParameter[] parameters = { new MySqlParameter("NguoiChungTu", NguoiCt),
                                            new MySqlParameter("NgayChungTu", DateTime.Now.ToString("yyyy/MM/dd"))};
            return Insert("chungtu ", cols, conditions, parameters);
        }

        public DataTable CheckInfor(string Ten, string SoCMT)
        {
            string[] cols = { "Id" };
            string[] conditions = { "Ten = @Ten", "SoCMT = @SoCMT"};
            MySqlParameter[] parameters = { new MySqlParameter("Ten", Ten),
                                            new MySqlParameter("SoCMT", SoCMT)};
            return Select("nguoi", cols, conditions, parameters);
        }
        public int AddNguoi(string Ten, string Sdt, string SoCMT, string NgayCap, string NoiCap, string DiaChi)
        {
            string[] cols = { "Ten", "Sdt", "SoCMT", "NgayCap", "NoiCap", "DiaChi"};
            string[] conditions = { "@Ten", "@Sdt", "@SoCMT", "@NgayCap", "@NoiCap", "@DiaChi"};
            MySqlParameter[] parameters = { new MySqlParameter("Ten", Ten),
                                            new MySqlParameter("Sdt", Sdt),
                                            new MySqlParameter("SoCMT", SoCMT),
                                            new MySqlParameter("NgayCap", NgayCap),
                                            new MySqlParameter("NoiCap", NoiCap),
                                            new MySqlParameter("DiaChi", DiaChi)};
            return Insert("nguoi", cols, conditions, parameters);
        }

        public int AddPhieuCam(string NguoiId, string SoTien, string CacTinhLaiId, string NgayVay, string HanTra ,string NoiCatGiu, string NoiDung)
        {
            string[] cols = { "NguoiId", "ChungTuId", "SoTien", "CachTinhLaiId", "NgayVay", "HanTra", "NoiCatGiu", "NoiDung", "TrangThai"};
            string[] conditions = { "@NguoiId", "@ChungTuId", "@SoTien", "@CachTinhLaiId", "@NgayVay", "@HanTra", "@NoiCatGiu", "@NoiDung", "@TrangThai"};
            MySqlParameter[] parameters = { new MySqlParameter("NguoiId", NguoiId),
                                            new MySqlParameter("ChungTuId", GetIdNewRecord("chungtu")),
                                            new MySqlParameter("SoTien", SoTien),
                                            new MySqlParameter("CachTinhLaiId", CacTinhLaiId),
                                            new MySqlParameter("NgayVay", NgayVay),
                                            new MySqlParameter("HanTra", HanTra),
                                            new MySqlParameter("NoiCatGiu", NoiCatGiu),
                                            new MySqlParameter("NoiDung", NoiDung),
                                            new MySqlParameter("TrangThai", "Bình thường")};
            return Insert("phieucam", cols, conditions, parameters);
        }

        public int AddPhieuVay(string NguoiId, string SoTien, string CacTinhLaiId, string NgayVay, string HanTra, string NoiCatGiu, string NoiDung)
        {
            string[] cols = { "NguoiId", "ChungTuId", "SoTien", "CachTinhLaiId", "NgayVay", "HanTra", "NoiCatGiu", "NoiDung", "TrangThai" };
            string[] conditions = { "@NguoiId", "@ChungTuId", "@SoTien", "@CachTinhLaiId", "@NgayVay", "@HanTra", "@NoiCatGiu", "@NoiDung", "@TrangThai" };
            MySqlParameter[] parameters = { new MySqlParameter("NguoiId", NguoiId),
                                            new MySqlParameter("ChungTuId", GetIdNewRecord("chungtu")),
                                            new MySqlParameter("SoTien", SoTien),
                                            new MySqlParameter("CachTinhLaiId", CacTinhLaiId),
                                            new MySqlParameter("NgayVay", NgayVay),
                                            new MySqlParameter("HanTra", HanTra),
                                            new MySqlParameter("NoiCatGiu", NoiCatGiu),
                                            new MySqlParameter("NoiDung", NoiDung),
                                            new MySqlParameter("TrangThai", "Bình thường")};
            return Insert("phieuvay", cols, conditions, parameters);
        }

        public int AddKhoHang(string NhomId, string PhieuCamId, string TrangThai,string TenHang, string SoLuong, string DinhGia, string ChuThich)
        {
            string[] cols = {"NhomId", "PhieuCamId","TrangThai" ,"TenHang", "SoLuong", "DinhGia", "ChuThich"};
            string[] conditions = { "@NhomId", "@PhieuCamId", "@TrangThai", "@TenHang", "@SoLuong", "@DinhGia", "@ChuThich"};
            MySqlParameter[] parameters = { new MySqlParameter("NhomId", NhomId),
                                            new MySqlParameter("PhieuCamId", PhieuCamId),
                                            new MySqlParameter("TrangThai", TrangThai),
                                            new MySqlParameter("TenHang", TenHang),
                                            new MySqlParameter("SoLuong", SoLuong),
                                            new MySqlParameter("DinhGia", DinhGia),
                                            new MySqlParameter("ChuThich", ChuThich)};
            return Insert("khohang", cols, conditions, parameters);
        }
        public DataTable SearchTenHang(string TenHang)
        {
            string[] cols = { "TenHang", "DVT", "SoLuong", "DinhGia", "NguonHang", "NgayTao", "ChuThich" };
            string[] conditions = {"TenHang LIKE '%" + TenHang +"%'"};
            MySqlParameter[] parameters = {};
            return Select("khohang", cols, conditions, parameters);
        }

        public DataTable GetAll(string table)
        {
            string[] cols = { "*" };
            string[] conditions = { };
            MySqlParameter[] parameters = { };
            return Select(table, cols, conditions, parameters);
        }

        public DataTable GetAllPhieuCamVay(string table)
        {
            string[] cols = { "*" };
            string[] conditions = {"TrangThai <> @TrangThai"};
            MySqlParameter[] parameters = { new MySqlParameter("TrangThai", "Đã thanh toán") };
            return Select(table, cols, conditions, parameters);
        }

        public DataTable GetAllId(string table, string Id)
        {
            string[] cols = { "*" };
            string[] conditions = { "Id = @Id"};
            MySqlParameter[] parameters = { new MySqlParameter("Id", Id) };
            return Select(table, cols, conditions, parameters);
        }

        public DataTable GetAllHang(string table, string Id)
        {
            string[] cols = { "*" };
            string[] conditions = { "PhieuCamId = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("Id", Id) };
            return Select(table, cols, conditions, parameters);
        }


        public int AddCachTinhLai(string TenLai, string TiLeLai, string KieuTinh, string QuyDoi, string ChuThich)
        {
            string[] cols = { "TenLai", "TiLeLai", "KieuTinh", "QuyDoi", "ChuThich"};
            string[] conditions = { "@TenLai", "@TiLeLai", "@KieuTinh", "@QuyDoi", "@ChuThich" };
            MySqlParameter[] parameters = { new MySqlParameter("TenLai", TenLai),
                                            new MySqlParameter("TiLeLai", TiLeLai),
                                            new MySqlParameter("KieuTinh", KieuTinh),
                                            new MySqlParameter("QuyDoi", QuyDoi),
                                            new MySqlParameter("ChuThich", ChuThich)};
            return Insert("cachtinhlai", cols, conditions, parameters);
        }

        public int UpdateCachTinhLai(string Id, string TenLai, string TiLeLai, string KieuTinh, string QuyDoi, string ChuThich)
        {
            string[] cols = { "TenLai = @TenLai", "TiLeLai = @TiLeLai", "KieuTinh = @KieuTinh", "QuyDoi = @QuyDoi", "ChuThich = @ChuThich" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("TenLai", TenLai),
                                            new MySqlParameter("TiLeLai", TiLeLai),
                                            new MySqlParameter("KieuTinh", KieuTinh),
                                            new MySqlParameter("QuyDoi", QuyDoi),
                                            new MySqlParameter("ChuThich", ChuThich),
                                            new MySqlParameter("Id", Id)};

            return Update("cachtinhlai", cols, conditions, parameters);
        }

        public int AddNhomKhachHang(string NhomKhachHang, string ChuThich)
        {
            string[] cols = { "NhomKhachHang", "ChuThich" };
            string[] conditions = { "@NhomKhachHang", "@ChuThich" };
            MySqlParameter[] parameters = { new MySqlParameter("NhomKhachHang", NhomKhachHang),
                                            new MySqlParameter("ChuThich", ChuThich)};
            return Insert("nhomkhachhang", cols, conditions, parameters);
        }

        public int UpdateNhomKhachHang(string Id, string NhomKhachHang, string ChuThich)
        {
            string[] cols = { "NhomKhachHang = @NhomKhachHang", "ChuThich = @ChuThich" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("NhomKhachHang", NhomKhachHang),
                                            new MySqlParameter("ChuThich", ChuThich),
                                            new MySqlParameter("Id", Id)};

            return Update("nhomkhachhang", cols, conditions, parameters);
        }

        public int AddNhomHang(string NhomHangHoa, string DonViTinh ,string ChuThich)
        {
            string[] cols = { "NhomHangHoa", "DonViTinh", "ChuThich" };
            string[] conditions = { "@NhomHangHoa", "@DonViTinh", "@ChuThich" };
            MySqlParameter[] parameters = { new MySqlParameter("NhomHangHoa", NhomHangHoa),
                                            new MySqlParameter("DonViTinh", DonViTinh),
                                            new MySqlParameter("ChuThich", ChuThich)};
            return Insert("nhomhanghoa", cols, conditions, parameters);
        }

        public int UpdateNhomHang(string Id, string NhomHangHoa,string DonViTinh, string ChuThich)
        {
            string[] cols = { "NhomHangHoa = @NhomHangHoa", "DonViTinh = @DonViTinh","ChuThich = @ChuThich" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("NhomHangHoa", NhomHangHoa),
                                            new MySqlParameter("DonViTinh", DonViTinh),
                                            new MySqlParameter("ChuThich", ChuThich),
                                            new MySqlParameter("Id", Id)};

            return Update("nhomhanghoa", cols, conditions, parameters);
        }

        public int DeleteFormTable(string Id, string table)
        {
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("Id", Id) };
            return Delete(table, conditions, parameters);
        }

        public DataTable SearchBetweenDay (string dayBegin, string dayEnd, string view)
        {
            string[] cols = {"*"};
            string[] conditions = { "NgayVay BETWEEN @dayBegin AND @dayEnd" };
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd)};
            return Select(view, cols, conditions, parameters);
        }

        public DataTable SearchOutDay(string table)
        {
            string[] cols = { "*" };
            string[] conditions = { "NgayQuaHan >= 0" };
            MySqlParameter[] parameters = {};
            return Select(table, cols, conditions, parameters);
        }

        public int AddPhieuThuChi(string LoaiPhieuId, string NguoiId, string SoTien, string NoiDung)
        {
            string[] cols = { "LoaiPhieuId", "ChungTuId", "NguoiId", "SoTien", "NoiDung"};
            string[] conditions = { "@LoaiPhieuId", "@ChungTuId", "@NguoiId", "@SoTien", "@NoiDung" };
            MySqlParameter[] parameters = { new MySqlParameter("LoaiPhieuId", LoaiPhieuId),
                                            new MySqlParameter("ChungTuId", GetIdNewRecord("chungtu")),
                                            new MySqlParameter("NguoiId", NguoiId),
                                            new MySqlParameter("SoTien", SoTien),
                                            new MySqlParameter("NoiDung", NoiDung)};
            return Insert("phieuthuchi", cols, conditions, parameters);
        }

        public DataTable GetPhieuThu()
        {
            string[] cols = { "*" };
            string[] conditions = { "LoaiPhieu = @LoaiPhieu" };
            MySqlParameter[] parameters = { new MySqlParameter("LoaiPhieu", "Phiếu thu") };
            return Select("view_thuchi", cols, conditions, parameters);
        }

        public DataTable SearchBetweenDay2(string dayBegin, string dayEnd, string LoaiPhieu)
        {
            string[] cols = { "*" };
            string[] conditions = { "NgayLap BETWEEN @dayBegin AND @dayEnd", "LoaiPhieu = @LoaiPhieu" };
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd),
                                            new MySqlParameter("LoaiPhieu", LoaiPhieu)};
            return Select("view_thuchi", cols, conditions, parameters);
        }
        public DataTable GetPhieuChi()
        {
            string[] cols = { "*" };
            string[] conditions = { "LoaiPhieu = @LoaiPhieu" };
            MySqlParameter[] parameters = { new MySqlParameter("LoaiPhieu", "Phiếu chi") };
            return Select("view_thuchi", cols, conditions, parameters);
        }

        public DataTable SearchName(string name, string table, string LoaiPhieu)
        {
            string[] cols = { "*" };
            string[] conditions = { "KhachHang = @KhachHang", "LoaiPhieu = @LoaiPhieu" };
            MySqlParameter[] parameters = { new MySqlParameter("KhachHang", name),
                                            new MySqlParameter("LoaiPhieu", LoaiPhieu)};
            return Select(table, cols, conditions, parameters);
        }

        public DataTable SearchName2(string name, string table)
        {
            string[] cols = { "*" };
            string[] conditions = { "Ten = @Ten"};
            MySqlParameter[] parameters = { new MySqlParameter("Ten", name)};
            return Select(table, cols, conditions, parameters);
        }

        public DataTable TimTenHang(string name)
        {
            string[] cols = { "*" };
            string[] conditions = { "TenHang = @TenHang"  };
            MySqlParameter[] parameters = { new MySqlParameter("TenHang", name)};
            return Select("view_khohangg", cols, conditions, parameters);
        }

        public DataTable TimTenNhom(string name)
        {
            string[] cols = { "*" };
            string[] conditions = { "NhomHangHoa = @TenHang" };
            MySqlParameter[] parameters = { new MySqlParameter("TenHang", name) };
            return Select("view_khohangg", cols, conditions, parameters);
        }

        public DataTable TimLoaiHang(string name)
        {
            string[] cols = { "*" };
            string[] conditions = { "TrangThai = @TenHang" };
            MySqlParameter[] parameters = { new MySqlParameter("TenHang", name) };
            return Select("view_khohangg", cols, conditions, parameters);
        }

        public int GiaHanTraLai(string table, string Id, string hantra)
        {
            string[] cols = { "NgayVay = @NgayVay", "HanTra = @HanTra", "TrangThai = @TrangThai" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("NgayVay", DateTime.Now.ToString("yyyy/MM/dd")),
                                            new MySqlParameter("HanTra", hantra),
                                            new MySqlParameter("TrangThai", "Đã gia hạn"),
                                            new MySqlParameter("Id", Id)};

            return Update(table , cols, conditions, parameters);
        }

        public int GiaHanCongGoc(string table, string Id, string hantra, string tiengoc, string tienlai)
        {
            int tongtien = Convert.ToInt32(tiengoc) + Convert.ToInt32(tienlai);
            string[] cols = { "NgayVay = @NgayVay", "HanTra = @HanTra", "SoTien = @SoTien", "TrangThai = @TrangThai" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("NgayVay", DateTime.Now.ToString("yyyy/MM/dd")),
                                            new MySqlParameter("HanTra", hantra),
                                            new MySqlParameter("SoTien", tongtien),
                                            new MySqlParameter("TrangThai", "Đã gia hạn"),
                                            new MySqlParameter("Id", Id)};

            return Update(table, cols, conditions, parameters);
        }

        public int ThanhToanPhieu(string table, string Id)
        {
            string[] cols = {"TrangThai = @TrangThai" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("TrangThai", "Đã thanh toán"),
                                            new MySqlParameter("Id", Id)};

            return Update(table, cols, conditions, parameters);
        }
        public int ThanhLyPhieu(string table, string Id)
        {
            string[] cols = { "TrangThai = @TrangThai" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("TrangThai", "Đã thanh toán"),
                                            new MySqlParameter("Id", Id)};

            return Update(table, cols, conditions, parameters);
        }
        public int ThanhLyDo(string table, string Id)
        {
            string[] cols = { "TrangThai = @TrangThai" };
            string[] conditions = { "PhieuCamId = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("TrangThai", "Chờ thanh lý"),
                                            new MySqlParameter("Id", Id)};

            return Update(table, cols, conditions, parameters);
        }
        public int ChuocDo(string table, string Id)
        {
            string[] cols = { "TrangThai = @TrangThai" };
            string[] conditions = { "PhieuCamId = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("TrangThai", "Khách đã chuộc"),
                                            new MySqlParameter("Id", Id)};

            return Update(table, cols, conditions, parameters);
        }

        public DataTable GetKhoHangMuaBan()
        {
            string[] cols = { "*" };
            string[] conditions = { "TrangThai <> 'Hàng khách cầm' AND TrangThai <> 'Khách đã chuộc' AND TrangThai <> 'Đã thanh lý'" };
            MySqlParameter[] parameters = { };
            return Select("view_khohangg", cols, conditions, parameters);
        }

        public DataTable GetKhoHangThanhLy()
        {
            string[] cols = { "*" };
            string[] conditions = { "TrangThai = 'Chờ thanh lý'" };
            MySqlParameter[] parameters = { };
            return Select("view_khohangg", cols, conditions, parameters);
        }

        public DataTable GetKhoHangNgoai()
        {
            string[] cols = { "*" };
            string[] conditions = { "TrangThai = 'Hàng mua ngoài'" };
            MySqlParameter[] parameters = { };
            return Select("view_khohangg", cols, conditions, parameters);
        }

        public int AddHangMuaNgoai(string NhomHangHoaId, string TenHang, string SoLuong, string DinhGia)
        {
            string[] cols = { "NhomId", "TrangThai", "TenHang", "SoLuong", "DinhGia", "ChuThich" };
            string[] conditions = { "@NhomId", "@TrangThai", "@TenHang", "@SoLuong", "@DinhGia", "@ChuThich" };
            MySqlParameter[] parameters = { new MySqlParameter("NhomId", NhomHangHoaId),
                                            new MySqlParameter("TrangThai", "Hàng mua ngoài"),
                                            new MySqlParameter("TenHang", TenHang),
                                            new MySqlParameter("SoLuong", SoLuong),
                                            new MySqlParameter("DinhGia", DinhGia),
                                            new MySqlParameter("ChuThich", "Hàng mua bên ngoài bởi "+ Program.userName)};
            return Insert("khohang", cols, conditions, parameters);
        }

        public int ThanhLyHang(string table, string Id)
        {
            string[] cols = { "TrangThai = @TrangThai" };
            string[] conditions = { "Id = @Id" };
            MySqlParameter[] parameters = { new MySqlParameter("TrangThai", "Đã thanh lý"),
                                            new MySqlParameter("Id", Id)};

            return Update(table, cols, conditions, parameters);
        }

        public DataTable SearchTrangThai(string table, string trangthai)
        {
            string[] cols = { "*" };
            string[] conditions = { "TrangThai = @TrangThai" };
            MySqlParameter[] parameters = { new MySqlParameter("TrangThai", trangthai)};

            return Select(table, cols, conditions, parameters);
        }

        public DataTable SearchBetweenDayPhieu(string dayBegin, string dayEnd, string Table, string TrangThai)
        {
            string[] cols = { "*" };
            string[] conditions = { "NgayVay BETWEEN @dayBegin AND @dayEnd", "TrangThai = @TrangThai" };
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd),
                                            new MySqlParameter("TrangThai", TrangThai)};
            return Select(Table, cols, conditions, parameters);
        }

        public DataTable SearchBetweenDayPhieu2(string dayBegin, string dayEnd, string Table)
        {
            string[] cols = { "*" };
            string[] conditions = { "NgayVay BETWEEN @dayBegin AND @dayEnd"};
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd)};
            return Select(Table, cols, conditions, parameters);
        }

        public DataTable SearchBetweenDayThuChi(string dayBegin, string dayEnd, string TrangThai)
        {
            string[] cols = { "*" };
            string[] conditions = { "NgayLap BETWEEN @dayBegin AND @dayEnd", "LoaiPhieu = @TrangThai" };
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd),
                                            new MySqlParameter("TrangThai", TrangThai)};
            return Select("view_thuchi", cols, conditions, parameters);
        }

        public DataTable SearchBetweenDayThuChi2(string dayBegin, string dayEnd)
        {
            string[] cols = { "*" };
            string[] conditions = { "NgayLap BETWEEN @dayBegin AND @dayEnd" };
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd)};
            return Select("view_thuchi", cols, conditions, parameters);
        }

        public int LuuLichSu(string Loai, string SoTien, string Nguon)
        {
            string[] cols = { "Loai", "SoTien", "NguonGoc", "ThoiGian", "NguoiThucHien"};
            string[] conditions = { "@Loai", "@SoTien", "@NguonGoc", "@ThoiGian", "@NguoiThucHien" };
            MySqlParameter[] parameters = { new MySqlParameter("Loai", Loai),
                                            new MySqlParameter("SoTien", SoTien),
                                            new MySqlParameter("NguonGoc", Nguon),
                                            new MySqlParameter("ThoiGian", DateTime.Now.ToString("yyyy/MM/dd HH/mm")),
                                            new MySqlParameter("NguoiThucHien", Program.userName)};
            return Insert("lichsu", cols, conditions, parameters);
        }

        public DataTable SearchBetweenDayDoanhThu(string dayBegin, string dayEnd, string TrangThai)
        {
            string[] cols = { "*" };
            string[] conditions = { "ThoiGian BETWEEN @dayBegin AND @dayEnd", "Loai = @TrangThai" };
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd),
                                            new MySqlParameter("TrangThai", TrangThai)};
            return Select("lichsu", cols, conditions, parameters);
        }

        public DataTable SearchBetweenDayDoanhThu2(string dayBegin, string dayEnd)
        {
            string[] cols = { "*" };
            string[] conditions = { "ThoiGian BETWEEN @dayBegin AND @dayEnd" };
            MySqlParameter[] parameters = { new MySqlParameter("dayBegin", dayBegin),
                                            new MySqlParameter("dayEnd", dayEnd)};
            return Select("lichsu", cols, conditions, parameters);
        }
    }
}
