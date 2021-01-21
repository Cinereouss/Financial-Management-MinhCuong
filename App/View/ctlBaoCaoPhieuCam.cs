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
    public partial class ctlBaoCaoPhieuCam : UserControl
    {
        Query query = new Query();
        public ctlBaoCaoPhieuCam()
        {
            InitializeComponent();
        }

        private void ctlBaoCaoPhieuCam_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.GetAll("view_phieucam");
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoPhieuCam_Load(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Tất cả")
            {
                dataGridView1.DataSource = query.SearchBetweenDayPhieu2(dateTimePicker1.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"), "view_phieucam");
            }
            else
            {
                dataGridView1.DataSource = query.SearchBetweenDayPhieu(dateTimePicker1.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"), "view_phieucam", comboBox1.Text);
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
