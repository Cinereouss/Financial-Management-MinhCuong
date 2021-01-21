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
    public partial class ctlPhieuVay : UserControl
    {
        Query query = new Query();
        UserDao userDao = new UserDao(Program.strConnection);
        private DataTable dataTableLai = new DataTable();
        private DataTable dataTableNguoi = new DataTable();
        public ctlPhieuVay()
        {
            InitializeComponent();
        }

        private void ctlPhieuVay_Load(object sender, EventArgs e)
        {
            txtNguoiLap.Text = Program.userName;
            txtNgayLap.Text = DateTime.Now.ToString("yyyy / MM / dd");

            dataTableLai = query.GetAll("cachtinhlai");
            cbbCachTinhLai.DataSource = dataTableLai;
            cbbCachTinhLai.ValueMember = "Id";
            cbbCachTinhLai.DisplayMember = "TenLai";
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void getQuyDoi(string str)
        {
            for (int i = 0; i < dataTableLai.Rows.Count; i++)
            {
                DataRow row = dataTableLai.Rows[i];
                if (row[1].ToString() == str)
                    txtQuyDoi.Text = row[4].ToString();
            }
        }

        private void cbbCachTinhLai_SelectedValueChanged(object sender, EventArgs e)
        {
            getQuyDoi(cbbCachTinhLai.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query.AddChungTu(txtNguoiLap.Text);
            DataTable temp = query.CheckInfor(txtHoTen.Text, txtCMND.Text);
            if (temp.Rows.Count == 1)
            {
                query.AddPhieuVay(temp.Rows[0]["Id"].ToString(), nbudSoTien.Value.ToString(), cbbCachTinhLai.SelectedValue.ToString(), DateTime.Now.ToString("yyyy/MM/dd"), dateHanTra.Value.ToString("yyyy/MM/dd"), txtNoiCatTien.Text, txtNoiDung.Text);
            }
            else
            {
                query.AddNguoi(txtHoTen.Text, txtDienThoai.Text, txtCMND.Text, dateNgayCap.Value.ToString("yyyy/MM/dd"), txtNoiCap.Text, txtDiaChi.Text);
                query.AddPhieuVay(query.GetIdNewRecord("nguoi").ToString(), nbudSoTien.Value.ToString(), cbbCachTinhLai.SelectedValue.ToString(), DateTime.Now.ToString("yyyy/MM/dd"), dateHanTra.Value.ToString("yyyy/MM/dd"), txtNoiCatTien.Text, txtNoiDung.Text);
            }

            query.LuuLichSu("Chi", nbudSoTien.Value.ToString(), "Cho " + txtHoTen.Text + "vay tiền");
            MessageBox.Show("Tạo phiếu vay thành công");


        }
    }
}
