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
    public partial class frmGiaHanPhieuCam : Form
    {
        private int phieucamId;
        string tienlai;
        Query query = new Query();
        DataTable dataTableNguoi = new DataTable();
        DataTable dataTablePhieuCam = new DataTable();
        public frmGiaHanPhieuCam(int temp, string tienlaitemp)
        {
            InitializeComponent();
            phieucamId = temp;
            tienlai = tienlaitemp;
        }

        private void frmGiaHanPhieu_Load(object sender, EventArgs e)
        {
            dataTablePhieuCam = query.GetAllId("view_phieucam2", phieucamId.ToString());
            dataTableNguoi = query.GetAllId("nguoi", dataTablePhieuCam.Rows[0]["NguoiId"].ToString());
            dataGridView1.DataSource = query.GetAllHang("view_khohang", phieucamId.ToString());
            txtHoTen.Text = dataTableNguoi.Rows[0]["Ten"].ToString();
            txtCMND.Text = dataTableNguoi.Rows[0]["SoCMT"].ToString();
            dateNgayCap.Text = dataTableNguoi.Rows[0]["NgayCap"].ToString();
            txtNoiCap.Text = dataTableNguoi.Rows[0]["NoiCap"].ToString();
            txtDienThoai.Text = dataTableNguoi.Rows[0]["Sdt"].ToString();
            txtDiaChi.Text = dataTableNguoi.Rows[0]["DiaChi"].ToString();
            nbudSoTien.Text = dataTablePhieuCam.Rows[0]["SoTien"].ToString();
            dateHanTra.Text = dataTablePhieuCam.Rows[0]["HanTra"].ToString();
            cbbCachTinhLai.Text = dataTablePhieuCam.Rows[0]["TenLai"].ToString();
            txtQuyDoi.Text = dataTablePhieuCam.Rows[0]["QuyDoi"].ToString();
            txtNoiCatTien.Text = dataTablePhieuCam.Rows[0]["NoiCatGiu"].ToString();
            txtNoiDung.Text = dataTablePhieuCam.Rows[0]["NoiDung"].ToString();
            txtTienLai.Text = tienlai;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmGiaHan frm = new frmGiaHan(phieucamId, nbudSoTien.Text , tienlai, "phieucam", txtHoTen.Text);
            DialogResult dlr = frm.ShowDialog();
            if (dlr == DialogResult.OK)
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận toán toàn bộ lãi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query.ThanhToanPhieu("phieucam", phieucamId.ToString());
                query.ChuocDo("khohang", phieucamId.ToString());
                int temp = Convert.ToInt32(nbudSoTien.Text) + Convert.ToInt32(tienlai);
                query.LuuLichSu("Thu", temp.ToString() , "Thanh toán phiếu cầm của " + txtHoTen.Text);
                MessageBox.Show("Thành công.");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thanh lý toàn bộ hàng trong kho?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                query.ThanhLyPhieu("phieucam", phieucamId.ToString());
                query.ThanhLyDo("khohang", phieucamId.ToString());
                MessageBox.Show("Thành công.");
                this.Close();
            }
        }
    }
}
