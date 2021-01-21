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
    public partial class ctlGiaHan : UserControl
    {
        Query query = new Query();
        public ctlGiaHan()
        {
            InitializeComponent();
        }

        private void ctlGiaHan_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = query.GetAllPhieuCamVay("view_phieucam");
            dataGridView1.DataSource = query.GetAllPhieuCamVay("view_phieuvay");

            DataTable dataTable = query.GetAllPhieuCamVay("view_phieucam");
            DataTable dataTable1 = query.GetAllPhieuCamVay("view_phieuvay");

            DataRow row;
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                row = dataTable.Rows[i];
                textBox1.AutoCompleteCustomSource.Add(row[0].ToString());
            }

            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                row = dataTable1.Rows[i];
                textBox1.AutoCompleteCustomSource.Add(row[0].ToString());
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = query.SearchBetweenDay(dateEdit1.DateTime.ToString("yyyy/MM/dd"), dateEdit2.DateTime.ToString("yyyy/MM/dd"), "view_phieucam");
            dataGridView1.DataSource = query.SearchBetweenDay(dateEdit1.DateTime.ToString("yyyy/MM/dd"), dateEdit2.DateTime.ToString("yyyy/MM/dd"), "view_phieuvay");
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            dateEdit1_EditValueChanged(sender, e);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dataGridView.DataSource = query.SearchOutDay("view_phieucam");
            dataGridView1.DataSource = query.SearchOutDay("view_phieuvay");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlGiaHan_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = query.SearchName2(textBox1.Text, "view_phieucam");
            dataGridView1.DataSource = query.SearchName2(textBox1.Text, "view_phieuvay");
        }


        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView.SelectedRows[0];
            frmGiaHanPhieuCam frm = new frmGiaHanPhieuCam(Convert.ToInt32(row.Cells[10].Value), row.Cells[8].Value.ToString());
            frm.Show();
            ctlGiaHan_Load(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            frmGiaHanPhieuVay frm = new frmGiaHanPhieuVay(Convert.ToInt32(row.Cells[10].Value), row.Cells[8].Value.ToString());
            frm.Show();
            ctlGiaHan_Load(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
