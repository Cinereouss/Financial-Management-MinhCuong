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
    public partial class ctlNhomHang : UserControl
    {
        Query query = new Query();
        private int action = 0;
        public ctlNhomHang()
        {
            InitializeComponent();
        }

        private void ctlNhomHang_Load(object sender, EventArgs e)
        {
            grDieuHuong.Enabled = false;
            grThongTin.Enabled = false;
            dgvMain.DataSource = query.GetAll("nhomhanghoa");
            grbChucNang.Enabled = true;
            action = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            action = 0;
            ctlNhomHang_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            grbChucNang.Enabled = false;
            grDieuHuong.Enabled = true;
            grThongTin.Enabled = true;
            txtTenNhom.Text = "";
            txtChuThich.Text = "";
            txtDonViTinh.Text = "";
            action = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            grbChucNang.Enabled = false;
            grDieuHuong.Enabled = true;
            grThongTin.Enabled = true;
            action = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhóm hàng hóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                query.DeleteFormTable(dgvMain.SelectedRows[0].Cells[0].Value.ToString(), "nhomhanghoa");
                ctlNhomHang_Load(sender, e);
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count < 1) return;
            DataGridViewRow row = dgvMain.SelectedRows[0];
            txtTenNhom.Text = row.Cells[1].Value.ToString();
            txtDonViTinh.Text = row.Cells[2].Value.ToString();
            txtChuThich.Text = row.Cells[3].Value.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == 1)
                    query.AddNhomHang(txtTenNhom.Text, txtDonViTinh.Text, txtChuThich.Text);
                if (action == 2)
                    query.UpdateNhomHang(dgvMain.SelectedRows[0].Cells[0].Value.ToString(), txtTenNhom.Text, txtDonViTinh.Text, txtChuThich.Text);
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlNhomHang_Load(sender, e);
                action = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Cảnh báo thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
