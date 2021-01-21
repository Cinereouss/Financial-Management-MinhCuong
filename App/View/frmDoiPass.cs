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
    public partial class frmDoiPass : DevExpress.XtraEditors.XtraForm
    {
        UserDao userDao = new UserDao(Program.strConnection);

        public frmDoiPass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxMkCu.Text == "")
            {
                XtraMessageBox.Show("Mật khẩu cũ không được để trống!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            if (textBoxMKMoi.Text == "")
            {
                XtraMessageBox.Show("Mật khẩu mới không được để trống!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxNLMK.Text == "")
            {
                XtraMessageBox.Show("Nhập lại mật khẩu không được trống!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxMkCu.Text != Program.passWord)
            {
                XtraMessageBox.Show("Mật khẩu cũ không đúng!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxMkCu.Text == textBoxMKMoi.Text)
            {
                XtraMessageBox.Show("Mật khẩu mới không được giống mật khẩu cũ!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxMKMoi.Text != textBoxNLMK.Text)
            {
                XtraMessageBox.Show("Mật khẩu mới phải giống nhau!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(userDao.UpdatePassword(textBoxMKMoi.Text) == 1)
            {
                XtraMessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                XtraMessageBox.Show("Lỗi!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}