using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinhCuong.Class;

namespace MinhCuong.View
{
    public partial class ctlPhieuCamDo : UserControl
    {
        MyStr myStr = new MyStr();
        Query query = new Query();
        UserDao userDao = new UserDao(Program.strConnection);
        private DataTable dt = new DataTable();
        

        public ctlPhieuCamDo()
        {
            InitializeComponent();
        }

        private void ctlPhieuCamDo_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("DVT", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DinhGia", typeof(int));
            dt.Columns.Add("ChuThich", typeof(string));

            txtNguoiLap.Text = Program.userName;
            txtNgayLap.Text = DateTime.Now.ToString("yyyy / MM / dd");
            txtMaPhieu.Text = myStr.RandomString(10);

            cbbCachTinhLai.DataSource = userDao.GetAll("cachtinhlai");
            cbbCachTinhLai.ValueMember = "Id";
            cbbCachTinhLai.DisplayMember = "CachTinhLai";

            cbbNhomKH.DataSource = userDao.GetAll("nhomkhachhang");
            cbbNhomKH.DisplayMember = "NhomKhachHang";
            cbbNhomKH.ValueMember = "Id";
            gctl_main.DataSource = dt;
            
        }

        private void txtMaKH_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            
            query.AddChungTu(txtMaPhieu.Text, txtNguoiLap.Text, txtNgayLap.Text);
            query.AddNguoi(txtHoTen.Text, txtDienThoai.Text, txtCMND.Text, dateNgayCap.Value.ToString(), txtNoiCap.Text, txtDiaChi.Text, nbudCongNo.Value.ToString(), cbbNhomKH.SelectedValue.ToString());
            if(gridView1.RowCount == 0)
                query.AddPhieuCam(nbudSoTien.Value.ToString(), dateHanTra.Value.ToString(), cbbCachTinhLai.SelectedValue.ToString(), nbudQuaHan.Value.ToString(), txtNoiCatTien.Text, txtNoiDung.Text, "Phiếu vay");
            else
                query.AddPhieuCam(nbudSoTien.Value.ToString(), dateHanTra.Value.ToString(), cbbCachTinhLai.SelectedValue.ToString(), nbudQuaHan.Value.ToString(), txtNoiCatTien.Text, txtNoiDung.Text, "Phiếu cầm");
            DataRow row;
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                row = gridView1.GetDataRow(i);
                query.AddKhoHang(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), "Phiếu cầm của " + txtHoTen.Text);
            }
            MessageBox.Show("Thành công");
        }

        private void txtNguoiLap_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dtgv_HangHoa_SelectionChanged(object sender, EventArgs e)
        {
          
        }
    }
}
