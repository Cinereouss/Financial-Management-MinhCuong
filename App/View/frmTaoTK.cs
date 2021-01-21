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
    public partial class frmTaoTK : DevExpress.XtraEditors.XtraForm
    {
        UserDao userDao = new UserDao(Program.strConnection); 

        public frmTaoTK()
        {
            InitializeComponent();
        }

        private void frmTaoTK_Load(object sender, EventArgs e)
        {
            cbbChucVu.DataSource = userDao.GetAll("chucvu");
            cbbChucVu.DisplayMember = "Ten";
            cbbChucVu.ValueMember = "Id";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(txtTk.Text == "")
            {
                XtraMessageBox.Show("Tên tài khoản không được để trống!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMK.Text == "")
            {
                XtraMessageBox.Show("Mật khẩu không được để trống!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNLMK.Text == "")
            {
                XtraMessageBox.Show("Hãy nhập lại mật khẩu không được trống!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNLMK.Text != txtMK.Text)
            {
                XtraMessageBox.Show("Mật khẩu mới phải giống nhau!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (userDao.CheckLogin(txtTk.Text) != 0)
            {
                XtraMessageBox.Show("Tài khoản này đã tồn tại");
                return;
            }
           if(userDao.CreateUser(txtTk.Text, txtMK.Text, cbbChucVu.SelectedValue.ToString()) == 1)
            {
                XtraMessageBox.Show("Thành công!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Lỗi!", "Hệ thống cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}