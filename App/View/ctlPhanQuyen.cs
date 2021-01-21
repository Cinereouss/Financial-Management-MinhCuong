using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinhCuong.View;
using MinhCuong.Class;
using DevExpress.XtraTab;

namespace MinhCuong.View
{
    public partial class ctlPhanQuyen : UserControl
    {
        AddTab addTab = new AddTab();
        XtraTabControl Tab;
        public ctlPhanQuyen(XtraTabControl tabControl)
        {
            InitializeComponent();
            Tab = tabControl;
        }

        public void AddPhanQuyen(frmMain ParentForm)
        {
            ParentForm.Ribbon.MergeRibbon(this.ribbonControl1);
        }

        public void AddCtl(frmMain ParentForm)
        {
            cltViewAllAccount clt = new cltViewAllAccount();
            addTab.AddTabControl(xtraTabControl, clt, "Thông tin tài khản");
        }

        private void btnTaoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTaoTK frmTaoTK = new frmTaoTK();
            frmTaoTK.Show();
        }

        private void btnViewAccont_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cltViewAllAccount clt = new cltViewAllAccount();

            addTab.AddTabControl(Tab, clt, "Thông tin tài khản");
        }
    }
}
