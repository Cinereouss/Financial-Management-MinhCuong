using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinhCuong.Class;

namespace MinhCuong.View
{
    public partial class frmNhapHang : Form
    {
        Query query = new Query();

        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = query.GetAll("nhomhanghoa");
            comboBox1.DisplayMember = "NhomHangHoa";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query.AddHangMuaNgoai(comboBox1.SelectedValue.ToString(), textBox1.Text, numericUpDown1.Value.ToString(), numericUpDown2.Value.ToString());
            query.LuuLichSu("Chi", numericUpDown2.Value.ToString(), "Nhâp hàng vào kho");
            MessageBox.Show("Mua hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
