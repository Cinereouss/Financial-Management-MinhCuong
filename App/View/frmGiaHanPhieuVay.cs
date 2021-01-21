using MinhCuong.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinhCuong.View
{
    public partial class frmGiaHanPhieuVay : Form
    {

        private int phieuvayId;
        string tienlai;
        Query query = new Query();
        DataTable dataTableNguoi = new DataTable();
        DataTable dataTablePhieuVay = new DataTable();
        public frmGiaHanPhieuVay(int temp, string tienlaitemp)
        {
            InitializeComponent();
            phieuvayId = temp;
            tienlai = tienlaitemp;
        }

        private void frmGiaHanPhieuVay_Load(object sender, EventArgs e)
        {
            dataTablePhieuVay = query.GetAllId("view_phieuvay2", phieuvayId.ToString());
            dataTableNguoi = query.GetAllId("nguoi", dataTablePhieuVay.Rows[0]["NguoiId"].ToString());

            txtHoTen.Text = dataTableNguoi.Rows[0]["Ten"].ToString();
            txtCMND.Text = dataTableNguoi.Rows[0]["SoCMT"].ToString();
            dateNgayCap.Text = dataTableNguoi.Rows[0]["NgayCap"].ToString();
            txtNoiCap.Text = dataTableNguoi.Rows[0]["NoiCap"].ToString();
            txtDienThoai.Text = dataTableNguoi.Rows[0]["Sdt"].ToString();
            txtDiaChi.Text = dataTableNguoi.Rows[0]["DiaChi"].ToString();
            nbudSoTien.Text = dataTablePhieuVay.Rows[0]["SoTien"].ToString();
            dateHanTra.Text = dataTablePhieuVay.Rows[0]["HanTra"].ToString();
            cbbCachTinhLai.Text = dataTablePhieuVay.Rows[0]["TenLai"].ToString();
            txtQuyDoi.Text = dataTablePhieuVay.Rows[0]["QuyDoi"].ToString();
            txtNoiCatTien.Text = dataTablePhieuVay.Rows[0]["NoiCatGiu"].ToString();
            txtNoiDung.Text = dataTablePhieuVay.Rows[0]["NoiDung"].ToString();
            txtTienLai.Text = tienlai;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmGiaHan frm = new frmGiaHan(phieuvayId, nbudSoTien.Text, tienlai, "phieuvay", txtHoTen.Text);
            DialogResult dlr = frm.ShowDialog();
            if (dlr == DialogResult.OK)
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhanh toán toàn bộ lãi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query.ThanhToanPhieu("phieuvay", phieuvayId.ToString());

                int temp = Convert.ToInt32(nbudSoTien.Text) + Convert.ToInt32(tienlai);
                query.LuuLichSu("Thu", temp.ToString(), "Thanh toán phiếu vay của " + txtHoTen.Text);

                MessageBox.Show("Thành công.");
                this.Close();
            }
        }
    }
}
