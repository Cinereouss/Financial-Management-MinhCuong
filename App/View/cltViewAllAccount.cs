using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MinhCuong.Class;

namespace MinhCuong.View
{
    public partial class cltViewAllAccount : DevExpress.XtraEditors.XtraUserControl
    {
        UserDao userDao = new UserDao(Program.strConnection);

        public cltViewAllAccount()
        {
            InitializeComponent();
        }

        private void cltViewAllAccount_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userDao.GetAll("view_user");
        }
    }
}
