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
    public partial class ctlBaoCaoThuChi : UserControl
    {
        Query query = new Query();
        public ctlBaoCaoThuChi()
        {
            InitializeComponent();
        }

        private void ctlBaoCaoThuChi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.GetAll("view_thuchi");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoThuChi_Load(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tất cả")
            {
                dataGridView1.DataSource = query.SearchBetweenDayThuChi2(dateTimePicker1.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }
            else
            {
                dataGridView1.DataSource = query.SearchBetweenDayThuChi(dateTimePicker1.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"), comboBox1.Text);
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
