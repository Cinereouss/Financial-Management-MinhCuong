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
    public partial class ctlMuaBan : UserControl
    {
        Query query = new Query();
        public ctlMuaBan()
        {
            InitializeComponent();
        }

        private void ctlMuaBan_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.GetKhoHangMuaBan();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlMuaBan_Load(sender, e);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dataGridView1.DataSource = query.GetKhoHangThanhLy();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dataGridView1.DataSource = query.GetKhoHangNgoai();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            DialogResult dlr = frm.ShowDialog();
            if(dlr == DialogResult.OK)
            {
                ctlMuaBan_Load(sender, e);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            frmBanHang frm = new frmBanHang(row.Cells[0].Value.ToString());
            if(frm.ShowDialog() == DialogResult.OK)
                ctlMuaBan_Load(sender, e);
        }
    }
}
