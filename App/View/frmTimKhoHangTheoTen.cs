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
    public partial class frmTimKhoHangTheoTen : Form
    {
        Query query = new Query();
        public DataTable dataTable = new DataTable();
        public frmTimKhoHangTheoTen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataTable = query.SearchTenHang(textBox1.Text);
        }
    }
}
