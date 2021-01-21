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
    public partial class ctlThuChi : UserControl
    {
        Query query = new Query();
        public ctlThuChi()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhieuThuChi frm = new frmPhieuThuChi();
            DialogResult dlr = frm.ShowDialog();
            if (dlr == DialogResult.OK)
                ctlThuChi_Load(sender, e);
        }

        private void ctlThuChi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.GetPhieuChi();
            dataGridView2.DataSource = query.GetPhieuThu();
            DataTable dataTable = query.GetAll("view_thuchi");
            DataRow row;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                row = dataTable.Rows[i];
                textBox1.AutoCompleteCustomSource.Add(row[1].ToString());
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.SearchBetweenDay2(dateEdit1.DateTime.ToString("yyyy/MM/dd"), dateEdit2.DateTime.ToString("yyyy/MM/dd"), "Phiếu chi");
            dataGridView2.DataSource = query.SearchBetweenDay2(dateEdit1.DateTime.ToString("yyyy/MM/dd"), dateEdit2.DateTime.ToString("yyyy/MM/dd"), "Phiếu thu");
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            dateEdit1_EditValueChanged(sender, e);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlThuChi_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.SearchName(textBox1.Text, "view_thuchi", "Phiếu chi");
            dataGridView2.DataSource = query.SearchName(textBox1.Text, "view_thuchi", "Phiếu thu");
        }
    }
}
