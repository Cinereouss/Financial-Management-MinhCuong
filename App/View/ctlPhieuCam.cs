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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace MinhCuong.View
{
    public partial class ctlPhieuCam : UserControl
    {
        Query query = new Query();
        UserDao userDao = new UserDao(Program.strConnection);
        private DataTable dataTableHangHoa = new DataTable();
        private DataTable dataTableLai = new DataTable();
        private DataTable dataTableNhomHangHoa = new DataTable();
        private DataTable dataTableNguoi = new DataTable();

        public ctlPhieuCam()
        {
            InitializeComponent();
        }

        private void ctlPhieuCamDo_Load(object sender, EventArgs e)
        {
            dataTableHangHoa.Columns.Add("NhomHangHoa", typeof(string));
            dataTableHangHoa.Columns.Add("TenHangHoa", typeof(string));
            dataTableHangHoa.Columns.Add("SoLuong", typeof(int));
            dataTableHangHoa.Columns.Add("DinhGia", typeof(int));
            dataTableHangHoa.Columns.Add("ChuThich", typeof(string));

            txtNguoiLap.Text = Program.userName;
            txtNgayLap.Text = DateTime.Now.ToString("yyyy / MM / dd");

            dataTableLai = query.GetAll("cachtinhlai");
            cbbCachTinhLai.DataSource = dataTableLai;
            cbbCachTinhLai.ValueMember = "Id";
            cbbCachTinhLai.DisplayMember = "TenLai";

            gridControl1.DataSource = dataTableHangHoa;

            dataTableNhomHangHoa = query.GetAll("nhomhanghoa");
            DataRow row;

            for (int i = 0; i < dataTableNhomHangHoa.Rows.Count; i++)
            {
                row = dataTableNhomHangHoa.Rows[i];
                repositoryItemComboBox1.Items.Add(row[1].ToString());
            }
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

        private string getIdNhomHang(string str)
        {
            for (int i = 0; i < dataTableNhomHangHoa.Rows.Count; i++)
            {
                DataRow row = dataTableNhomHangHoa.Rows[i];
                if (row[1].ToString() == str)
                    return row[0].ToString();
            }
            return null;
        }

        private void getQuyDoi(string str)
        {
            for (int i = 0; i < dataTableLai.Rows.Count; i++)
            {
                DataRow row = dataTableLai.Rows[i];
                if (row[1].ToString() == str)
                    txtQuyDoi.Text = row[4].ToString();
            }
        }
        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            query.AddChungTu(txtNguoiLap.Text);
            DataTable temp = query.CheckInfor(txtHoTen.Text, txtCMND.Text);

            if (dgrvMainHangHoa.RowCount != 1)
            {
                if (temp.Rows.Count == 1)
                {
                    query.AddPhieuCam(temp.Rows[0]["Id"].ToString(), nbudSoTien.Value.ToString(), cbbCachTinhLai.SelectedValue.ToString(), DateTime.Now.ToString("yyyy/MM/dd"), dateHanTra.Value.ToString("yyyy/MM/dd"), txtNoiCatTien.Text, txtNoiDung.Text);
                }
                else
                {
                    query.AddNguoi(txtHoTen.Text, txtDienThoai.Text, txtCMND.Text, dateNgayCap.Value.ToString("yyyy/MM/dd"), txtNoiCap.Text, txtDiaChi.Text);
                    query.AddPhieuCam(query.GetIdNewRecord("nguoi").ToString(), nbudSoTien.Value.ToString(), cbbCachTinhLai.SelectedValue.ToString(), DateTime.Now.ToString("yyyy/MM/dd"), dateHanTra.Value.ToString("yyyy/MM/dd"), txtNoiCatTien.Text, txtNoiDung.Text);
                }

                query.LuuLichSu("Chi", nbudSoTien.Value.ToString(), "Cho " + txtHoTen.Text + " cầm đồ");
                DataRow row;
                for (int i = 0; i < dgrvMainHangHoa.RowCount - 1; i++)
                {
                    row = dataTableHangHoa.Rows[i];
                    query.AddKhoHang(getIdNhomHang(row[0].ToString()).ToString(), query.GetIdNewRecord("phieucam").ToString(), "Hàng khách cầm", row[1].ToString(), row[2].ToString(), row[3].ToString(), "Phiếu cầm của " + txtHoTen.Text);
                }
                MessageBox.Show("Tạo phiếu cầm đồ thành công");
            }
            else
                MessageBox.Show("Bạn chưa nhập hàng hóa, vui lòng nhâp để tạo phiếu cầm đồ hoặc lựa chọn phiếu vay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        private void cbbCachTinhLai_SelectedValueChanged(object sender, EventArgs e)
        {
            getQuyDoi(cbbCachTinhLai.Text);
        }
    }
}
