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
    public partial class frmBanHang : Form
    {
        Query query = new Query();
        string idhang;
        DataTable dataTable;
        public frmBanHang(string id)
        {
            InitializeComponent();
            idhang = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query.ThanhLyHang("khohang", idhang);
            query.LuuLichSu("Thu", txtDinhGia.Text, "Thanh lý hàng trong kho");
            MessageBox.Show("Bán hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            dataTable = query.GetAllId("view_khohangg", idhang);

            txtNhomHang.Text = dataTable.Rows[0]["NhomHangHoa"].ToString();
            txtTen.Text = dataTable.Rows[0]["TenHang"].ToString();
            txtSoLuong.Text = dataTable.Rows[0]["SoLuong"].ToString();
            txtDinhGia.Text = dataTable.Rows[0]["DinhGia"].ToString();
            txtNguonHang.Text = dataTable.Rows[0]["ChuThich"].ToString();
        }
    }
}
