using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinhCuong.Class;

namespace MinhCuong.View
{
    public partial class frmPhieuThuChi : Form
    {
        Query query = new Query();
        MyStr myStr = new MyStr(); 

        public frmPhieuThuChi()
        {
            InitializeComponent();
        }

        private void frmPhieuThuChi_Load(object sender, EventArgs e)
        {
            txtNguoiLap.Text = Program.userName;
            txtNgayLap.Text = DateTime.Now.ToString("yyyy / MM / dd");
            txtMaPhieu.Text = myStr.RandomString(10);
            cbbLoaiPhieu.DataSource = query.GetAll("loaiphieuthuchi");
            cbbLoaiPhieu.DisplayMember = "Ten";
            cbbLoaiPhieu.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query.AddChungTu(txtNguoiLap.Text);
            DataTable temp = query.CheckInfor(txtHoTen.Text, txtCMND.Text);
            if (temp.Rows.Count == 1)
            {
                query.AddPhieuThuChi(cbbLoaiPhieu.SelectedValue.ToString(), temp.Rows[0]["Id"].ToString(), nbupSoTien.Value.ToString(), txtNoiDung.Text);
            }
            else
            {
                query.AddNguoi(txtHoTen.Text, txtDienThoai.Text, txtCMND.Text, dateNgayCap.Value.ToString("yyyy/MM/dd"), txtNoiCap.Text, txtDiaChi.Text);
                query.AddPhieuThuChi(cbbLoaiPhieu.SelectedValue.ToString(), query.GetIdNewRecord("nguoi").ToString(), nbupSoTien.Value.ToString(), txtNoiDung.Text);

            }

            if(cbbLoaiPhieu.Text == "Phiếu thu")
            {
                query.LuuLichSu("Thu", nbupSoTien.Value.ToString(), "Phiếu thu của " + txtHoTen.Text);
            }
            else
            {
                query.LuuLichSu("Chi", nbupSoTien.Value.ToString(), "Phiếu chi của " + txtHoTen.Text);
            }

            if (MessageBox.Show("Tạo " + cbbLoaiPhieu.Text + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }
    }
}
