using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MinhCuong.Class;

namespace MinhCuong.View
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        UserDao userDao = new UserDao(Program.strConnection);
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxUser.Text == "")
            {
                XtraMessageBox.Show("Tên tài khoản không được để trống! ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            if(textBoxPass.Text == "")
            {
                XtraMessageBox.Show("Mật khẩu không được để trống! ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int resultCheck = userDao.CheckLogin(textBoxUser.Text, textBoxPass.Text);
            if (resultCheck == -1)
                XtraMessageBox.Show("Sai mật khẩu! ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (resultCheck == 0)
                XtraMessageBox.Show("Tài khoản không tồn tại! ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (resultCheck == 1)
            {
                XtraMessageBox.Show("Đăng nhập thành công! \nTime: " + DateTime.Now.ToString(), "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            userDao.DeleteInformationUser();
        }
    }
}