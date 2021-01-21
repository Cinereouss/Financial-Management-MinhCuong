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
    public partial class ctlKhoHang : UserControl
    {
        DataTable dataTable;
        Query query = new Query();
        public ctlKhoHang()
        {
            InitializeComponent();
        }

        private void ctlKhoHang_Load(object sender, EventArgs e)
        {
            dataTable = query.GetAll("view_khohangg");

            DataRow row;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                row = dataTable.Rows[i];
                textBox1.AutoCompleteCustomSource.Add(row[1].ToString());
            }

            comboBoxNhom.DataSource = query.GetAll("nhomhanghoa");
            comboBoxNhom.DisplayMember = "NhomHangHoa";
            comboBoxNhom.ValueMember = "Id";

            dataGridView1.DataSource = query.GetAll("view_khohangg");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.TimTenHang(textBox1.Text);
        }

        private void comboBoxNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.TimTenNhom(comboBoxNhom.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = query.TimLoaiHang(comboBox2.Text);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ctlKhoHang_Load(sender, e);
        }
    }
}
