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
    public partial class ctlBaoCaoDoanhThu : UserControl
    {
        Query query = new Query();
        public ctlBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void ctlBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            dataGridView11.DataSource = query.GetAll("lichsu");
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlBaoCaoDoanhThu_Load(sender, e);
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "Tất cả")
            {
                dataGridView11.DataSource = query.SearchBetweenDayDoanhThu2(dateTimePicker11.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"));
            }
            else
            {
                dataGridView11.DataSource = query.SearchBetweenDayDoanhThu(dateTimePicker11.Value.ToString("yyyy/MM/dd"), dateTimePicker2.Value.ToString("yyyy/MM/dd"), comboBox11.Text);
            }
        }

        private void dateTimePicker11_ValueChanged(object sender, EventArgs e)
        {
            comboBox11_SelectedIndexChanged(sender, e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            comboBox11_SelectedIndexChanged(sender, e);
        }
    }
}
