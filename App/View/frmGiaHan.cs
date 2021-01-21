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
    public partial class frmGiaHan : Form
    {
        int phieucamid;
        string tiengoc, tienlai, table, name;
        DateTime today = DateTime.Now;
        Query query = new Query();
        public frmGiaHan(int temp, string tiengoctemp, string tienlaitemp, string tabletemp, string nametemp)
        {
            InitializeComponent();
            phieucamid = temp;
            tiengoc = tiengoctemp;
            tienlai = tienlaitemp;
            table = tabletemp;
            name = nametemp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = today.AddDays(Convert.ToDouble(numericUpDown1.Value));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                query.GiaHanCongGoc(table, phieucamid.ToString(), dateTimePicker1.Value.ToString("yyyy/MM/dd"), tiengoc, tienlai);
            }
            else
            {
                query.GiaHanTraLai(table, phieucamid.ToString(), dateTimePicker1.Value.ToString("yyyy/MM/dd"));

                if(table == "phieucam")
                { 
                    query.LuuLichSu("Thu", tienlai, "Gia hạn phiếu cầm của " + name);
                }
                else
                {
                    query.LuuLichSu("Thu", tienlai, "Gia hạn phiếu vay của " + name);
                }
            }
            MessageBox.Show("Gia hạn thành công");
        }
    }
}
