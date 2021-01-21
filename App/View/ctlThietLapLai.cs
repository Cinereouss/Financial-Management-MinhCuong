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
    public partial class ctlThietLapLai : UserControl
    {
        Query query = new Query();
        private int action = 0;

        public ctlThietLapLai()
        {
            InitializeComponent();
        }

        private void ctlThietLapLai_Load(object sender, EventArgs e)
        {
            grDieuHuong.Enabled = false;
            grThongTin.Enabled = false;
            dgvMain.DataSource = query.GetAll("cachtinhlai");
            grbChucNang.Enabled = true;
            action = 0;
        }

        private void dgvMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count < 1) return;
            DataGridViewRow row = dgvMain.SelectedRows[0];
            txtTenLai.Text = row.Cells[1].Value.ToString();
            nbudGiaTri.Value = Convert.ToDecimal(row.Cells[2].Value);
            ccbTinhLaiTheo.Text = row.Cells[3].Value.ToString();
            txtQuyDoi.Text = row.Cells[4].Value.ToString();
            txtChuThich.Text = row.Cells[5].Value.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == 1)
                    query.AddCachTinhLai(txtTenLai.Text, nbudGiaTri.Value.ToString(), ccbTinhLaiTheo.Text, txtQuyDoi.Text, txtChuThich.Text);
                if (action == 2)
                    query.UpdateCachTinhLai(dgvMain.SelectedRows[0].Cells[0].Value.ToString(), txtTenLai.Text, nbudGiaTri.Value.ToString(), ccbTinhLaiTheo.Text, txtQuyDoi.Text, txtChuThich.Text);
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlThietLapLai_Load(sender, e);
                action = 0;
            }
            catch(Exception ex) {
                MessageBox.Show("Lỗi: " + ex, "Cảnh báo thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            action = 0;
            ctlThietLapLai_Load(sender, e);
        }

        private void ccbTinhLaiTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ccbTinhLaiTheo.SelectedIndex == 0)
            {
                txtQuyDoi.Text = String.Format("{0:0.0}", nbudGiaTri.Value);
                dvt.Text = "(nghìn)";
                nbudGiaTri.DecimalPlaces = 0;
            }                
            if (ccbTinhLaiTheo.SelectedIndex == 1)
            {
                txtQuyDoi.Text = String.Format("{0:0.0}", (nbudGiaTri.Value / 7));
                dvt.Text = "(nghìn)";
                nbudGiaTri.DecimalPlaces = 0;
            }
            if (ccbTinhLaiTheo.SelectedIndex == 2)
            {
                txtQuyDoi.Text = String.Format("{0:0.0}", (nbudGiaTri.Value / 30));
                dvt.Text = "(nghìn)";
                nbudGiaTri.DecimalPlaces = 0;
            }
            if (ccbTinhLaiTheo.SelectedIndex == 3)
            {
                txtQuyDoi.Text = txtQuyDoi.Text = String.Format("{0:0.0}", ((decimal)1000000 * (nbudGiaTri.Value / (decimal)100) / 7));
                dvt.Text = "(%)";
                nbudGiaTri.DecimalPlaces = 2;
            }
            if (ccbTinhLaiTheo.SelectedIndex == 4)
            {
                txtQuyDoi.Text = txtQuyDoi.Text = String.Format("{0:0.0}", ((decimal)1000000 * (nbudGiaTri.Value / (decimal)100) / 30));
                dvt.Text = "(%)";
                nbudGiaTri.DecimalPlaces = 2;
            }
            if (ccbTinhLaiTheo.SelectedIndex == 5)
            {
                txtQuyDoi.Text = txtQuyDoi.Text = String.Format("{0:0.0}", ((decimal)1000000 * (nbudGiaTri.Value / (decimal)100) / 365));
                dvt.Text = "(%)";
                nbudGiaTri.DecimalPlaces = 2;
            }
        }

        private void nbudGiaTri_ValueChanged(object sender, EventArgs e)
        {
            ccbTinhLaiTheo_SelectedIndexChanged(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            grbChucNang.Enabled = false;
            grDieuHuong.Enabled = true;
            grThongTin.Enabled = true;
            txtTenLai.Text = "";
            txtChuThich.Text = "";
            txtQuyDoi.Text = "";
            nbudGiaTri.Value = 0;
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
            if(MessageBox.Show("Xóa cách tính lãi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                query.DeleteFormTable(dgvMain.SelectedRows[0].Cells[0].Value.ToString(), "cachtinhlai");
            ctlThietLapLai_Load(sender, e);
        }
    }
}
