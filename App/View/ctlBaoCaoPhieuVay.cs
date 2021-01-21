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
   
    public partial class ctlBaoCaoPhieuVay : UserControl
    {
        Query query = new Query();
        public ctlBaoCaoPhieuVay()
        {
            InitializeComponent();
        }

        private void ctlBaoCaoPhieuVay_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.GetAll("view_phieuvay");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoPhieuVay_Load(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Tất cả")
            {
                dataGridView1.DataSource = query.SearchBetweenDayPhieu2(dateTimePicker1.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"), "view_phieuvay");
            }
            else
            {
                dataGridView1.DataSource = query.SearchBetweenDayPhieu(dateTimePicker1.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"), "view_phieuvay", comboBox1.Text);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            comboBox1_SelectedIndexChanged(sender, e);
        }
    }
}
